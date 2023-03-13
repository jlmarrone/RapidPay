using Microsoft.Extensions.Caching.Memory;
using RapidPay.Abstractions.Services;
using RapidPay.Common.Constants;
using System.Globalization;

namespace RapidPay.Services.Services
{
    public class UniversalFeesExchangeService : IUniversalFeesExchangeService
    {
        private decimal _lastCalculatedFee = 1;
        private const string _cacheKey = "universalFee";

        private readonly IMemoryCache _memoryCache;

        public UniversalFeesExchangeService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public decimal CalculateUniversalFee()
        {
            decimal cachedFee = this._memoryCache.GetOrCreate(_cacheKey, entry =>
            {
                entry.SetSlidingExpiration(TimeSpan.FromMinutes(60));

                GetNextRandom(out Random random, out int next);

                var decimalPart = GetDecimalPart(random, next);

                var randomValue = Convert.ToDecimal($"{next}{CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator}{decimalPart}");

                var finalFee = GetFinalFee(randomValue);

                _lastCalculatedFee = randomValue;

                return finalFee;
            });

            return cachedFee;
        }

        private decimal GetFinalFee(decimal randomValue)
        {
            return randomValue * _lastCalculatedFee;
        }

        private static int GetDecimalPart(Random random, int next)
        {
            return next == 2 ? 0 : random.Next(0, 99);
        }

        private static void GetNextRandom(out Random random, out int next)
        {
            random = new Random();
            next = random.Next(
                        UniversalFeesExchangeConstants.Zero,
                        UniversalFeesExchangeConstants.Two);
        }
    }
}

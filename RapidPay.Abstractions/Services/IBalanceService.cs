using RapidPay.Core.Dtos;

namespace RapidPay.Abstractions.Services
{
    public interface IBalanceService
    {
        Task<BalanceDto> GetByCardAsync(Guid cardId);
    }
}

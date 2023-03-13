using RapidPay.Abstractions.Repositories;
using RapidPay.Abstractions.Services;
using RapidPay.Core.Dtos;

namespace RapidPay.Services.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IUniversalFeesExchangeService _universalFeesExchangeService;

        public PaymentService(
            IPaymentRepository paymentRepository,
            IUniversalFeesExchangeService universalFeesExchangeService)
        {
            _paymentRepository = paymentRepository;
            _universalFeesExchangeService = universalFeesExchangeService;
        }

        public async Task<PaymentDto> CreateAsync(Guid cardId, decimal totalAmount)
        {
            totalAmount += _universalFeesExchangeService.CalculateUniversalFee();

            var newPayment = await _paymentRepository.CreateAsync(cardId, totalAmount);

            return newPayment.ToPaymentDto();
        }
    }
}

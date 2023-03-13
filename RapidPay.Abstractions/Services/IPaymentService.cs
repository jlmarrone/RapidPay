using RapidPay.Core.Dtos;

namespace RapidPay.Abstractions.Services
{
    public interface IPaymentService
    {
        Task<PaymentDto> CreateAsync(Guid cardId, decimal totalAmount);
    }
}

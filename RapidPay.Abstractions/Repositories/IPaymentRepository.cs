using RapidPay.Core.Entities;

namespace RapidPay.Abstractions.Repositories
{
    public interface IPaymentRepository
    {
        Task<Payment> CreateAsync(Guid cardId, decimal totalAmount);
        Task<decimal> GetBalanceByCardAsync(Guid cardId);
    }
}

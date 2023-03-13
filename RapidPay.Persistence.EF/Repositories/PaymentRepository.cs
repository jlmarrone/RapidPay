using Microsoft.EntityFrameworkCore;
using RapidPay.Abstractions.Repositories;
using RapidPay.Core.Entities;
using RapidPay.Persistence.EF.Persistence;

namespace RapidPay.Persistence.EF.Repositories
{
    public class PaymentRepository : BaseRepository, IPaymentRepository
    {
        public PaymentRepository(RapidPayDbContext rapidPayDbContext) : base(rapidPayDbContext)
        {
        }

        public async Task<Payment> CreateAsync(Guid cardId, decimal totalAmount)
        {
            var newPaymet = new Payment(cardId, totalAmount);

            _rapidPayDbContext.Payments.Add(newPaymet);

            await _rapidPayDbContext.SaveChangesAsync();

            return newPaymet;
        }

        public async Task<decimal> GetBalanceByCardAsync(Guid cardId)
        {
            var payments = await GetByCardIdAsync(cardId);

            return payments.Sum(x => x.Amount);
        }

        private async Task<IEnumerable<Payment>> GetByCardIdAsync(Guid cardId) =>
            await _rapidPayDbContext.Payments.Where(x => x.CardId == cardId).ToListAsync();
    }
}

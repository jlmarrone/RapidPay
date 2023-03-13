using RapidPay.Core.Dtos;

namespace RapidPay.Core.Entities
{
    public class Payment : BaseEntity
    {
        public Payment(Guid cardId, decimal amount)
        {
            CardId = cardId;
            Amount = amount;
            Date = DateTime.UtcNow;
        }

        public Guid CardId { get; private set; }
        public DateTime Date { get; private set; }
        public decimal Amount { get; private set; }

        public PaymentDto ToPaymentDto() => new()
        {
            CardId = CardId,
            Amount = Amount,
        };
    }
}

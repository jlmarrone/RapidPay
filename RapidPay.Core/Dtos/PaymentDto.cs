namespace RapidPay.Core.Dtos
{
    public class PaymentDto
    {
        public Guid CardId { get; set; }
        public decimal Amount { get; set; }
    }
}

using RapidPay.Core.Dtos;

namespace RapidPay.Core.Entities
{
    public class Card : BaseEntity
    {
        public Card(string number)
        {
            Number = number;
        }

        public string Number { get; private set; }

        public CardDto ToCardDto() => new()
        {
            Id = Id,
            Number = Number,
        };
    }
}

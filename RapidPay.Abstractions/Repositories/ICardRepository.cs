using RapidPay.Core.Entities;

namespace RapidPay.Abstractions.Repositories
{
    public interface ICardRepository
    {
        Task<Card> CreateAsync(Card card);

        Task<Card> GetByIdAsync(Guid cardId);
    }
}

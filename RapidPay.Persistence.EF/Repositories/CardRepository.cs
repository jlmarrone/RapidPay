using Microsoft.EntityFrameworkCore;
using RapidPay.Abstractions.Repositories;
using RapidPay.Core.Entities;
using RapidPay.Core.Exceptions;
using RapidPay.Persistence.EF.Persistence;

namespace RapidPay.Persistence.EF.Repositories
{
    public class CardRepository : BaseRepository, ICardRepository
    {
        public CardRepository(RapidPayDbContext rapidPayDbContext) : base(rapidPayDbContext)
        {
        }

        public async Task<Card> CreateAsync(Card card)
        {
            await ValidateCardExistence(card);

            var newCard = new Card(card.Number);

            _rapidPayDbContext.Cards.Add(newCard);

            await _rapidPayDbContext.SaveChangesAsync();

            return newCard;
        }

        public async Task<Card> GetByIdAsync(Guid cardId) =>
            await _rapidPayDbContext.Cards.FirstOrDefaultAsync(x => x.Id == cardId);

        private async Task ValidateCardExistence(Card card)
        {
            var existsByNumber = await ExistsByNumber(card.Number);

            if (existsByNumber)
            {
                throw new BadRequestException()
                {
                    ErrorMessage = $"A card with number: {card.Number} already exists."
                };
            }
        }

        private async Task<bool> ExistsByNumber(string cardNumber)
        {
            return await _rapidPayDbContext.Cards
                            .AnyAsync(x => x.Number.ToLower() == cardNumber.ToLower());
        }
    }
}

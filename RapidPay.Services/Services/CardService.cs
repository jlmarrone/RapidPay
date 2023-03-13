using RapidPay.Abstractions.Repositories;
using RapidPay.Abstractions.Services;
using RapidPay.Core.Dtos;
using RapidPay.Core.Entities;

namespace RapidPay.Services.Services
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;
        public CardService(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }
        public async Task<CardDto> CreateAsync(Card card)
        {
            var newCard = await _cardRepository.CreateAsync(card);

            return newCard.ToCardDto();
        }

        public async Task<CardDto> GetByIdAsync(Guid cardId)
        {
            var card = await _cardRepository.GetByIdAsync(cardId);

            return card.ToCardDto();
        }
    }
}

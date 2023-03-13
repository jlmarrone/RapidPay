using RapidPay.Abstractions.Repositories;
using RapidPay.Abstractions.Services;
using RapidPay.Core.Dtos;
using RapidPay.Core.Exceptions;

namespace RapidPay.Services.Services
{
    public class BalanceService : IBalanceService
    {
        private readonly ICardRepository _cardRepository;
        private readonly IPaymentRepository _paymentRepository;

        public BalanceService(
            ICardRepository cardRepository,
            IPaymentRepository paymentRepository)
        {
            _cardRepository = cardRepository;
            _paymentRepository = paymentRepository;
        }

        public async Task<BalanceDto> GetByCardAsync(Guid cardId)
        {
            await CheckCardExistenceAsync(cardId);

            var cardBalance = await _paymentRepository.GetBalanceByCardAsync(cardId);

            return new BalanceDto
            {
                Amount = cardBalance
            };
        }

        private async Task CheckCardExistenceAsync(Guid cardId)
        {
            var card = await _cardRepository.GetByIdAsync(cardId);

            if (card == null)
            {
                throw new NotFoundException()
                {
                    ErrorMessage = $"Card with Id: {cardId} does not exist.",
                };
            }
        }
    }
}

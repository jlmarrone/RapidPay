using MediatR;
using RapidPay.Abstractions.Services;
using RapidPay.Core.Dtos;
using RapidPay.Core.Entities;

namespace RapidPay.Application.UseCases.Cards.Commands.Create
{
    internal class CreateCardCommandHandler : IRequestHandler<CreateCardCommand, CardDto>
    {
        private readonly ICardService _cardService;
        public CreateCardCommandHandler(ICardService cardService)
        {
            _cardService = cardService;
        }

        public async Task<CardDto> Handle(CreateCardCommand request, CancellationToken cancellationToken)
        {
            return await _cardService.CreateAsync(new Card(request.Number));
        }
    }
}

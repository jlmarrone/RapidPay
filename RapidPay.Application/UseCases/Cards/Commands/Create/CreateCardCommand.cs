using MediatR;
using RapidPay.Core.Dtos;

namespace RapidPay.Application.UseCases.Cards.Commands.Create
{
    public record CreateCardCommand : IRequest<CardDto>
    {
        public string Number { get; set; }
    }
}

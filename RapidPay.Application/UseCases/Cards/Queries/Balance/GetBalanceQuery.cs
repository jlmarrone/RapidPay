using MediatR;
using Microsoft.AspNetCore.Mvc;
using RapidPay.Core.Dtos;

namespace RapidPay.Application.UseCases.Cards.Queries.Balance
{
    public record GetBalanceQuery : IRequest<BalanceDto>
    {
        [FromRoute(Name = "id")]
        public Guid CardId { get; set; }
    }
}

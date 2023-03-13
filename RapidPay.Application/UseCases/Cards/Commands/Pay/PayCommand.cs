using MediatR;
using Microsoft.AspNetCore.Mvc;
using RapidPay.Core.Dtos;
using System.Text.Json.Serialization;

namespace RapidPay.Application.UseCases.Cards.Commands.Pay
{
    public record PayCommand : IRequest<PaymentDto>
    {
        [JsonIgnore]
        public Guid CardId { get; set; }

        [FromQuery(Name = "amount")]
        public decimal Amount { get; set; }
    }
}

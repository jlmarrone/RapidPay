using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RapidPay.API.Internal;
using RapidPay.Application.UseCases.Cards.Commands.Create;
using RapidPay.Application.UseCases.Cards.Commands.Pay;
using RapidPay.Application.UseCases.Cards.Queries.Balance;
using RapidPay.Core.Dtos;

namespace RapidPay.API.Controllers
{
    [Authorize]
    public class CardsController : BaseApiController
    {
        public CardsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [Route(Routing.Cards.Create)]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(typeof(CardDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateCard(CreateCardCommand createCardCommand)
        {
            return Ok(await _mediator.Send(createCardCommand));
        }

        [HttpPost]
        [Route(Routing.Cards.Pay)]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(typeof(PaymentDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> Pay(
            [FromRoute] Guid id,
            [FromBody] PayCommand payCommand)
        {
            return Ok(
                await _mediator.Send(payCommand with
                {
                    CardId = id,
                }));
        }

        [HttpGet]
        [Route(Routing.Cards.Balance)]
        [Authorize(Roles = "admin,guest")]
        [ProducesResponseType(typeof(BalanceDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> Balance([FromRoute] GetBalanceQuery getBalanceQuery)
        {
            return Ok(await _mediator.Send(getBalanceQuery));
        }
    }
}

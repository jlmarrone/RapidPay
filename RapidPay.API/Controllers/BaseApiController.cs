using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RapidPay.API.Controllers
{
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
        protected readonly IMediator _mediator;
        protected BaseApiController(IMediator mediator) => _mediator = mediator;
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RapidPay.Core.Exceptions;

namespace RapidPay.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<ExceptionFilter> _logger;

        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            context.Result = context.Exception switch
            {
                BadRequestException badRequest => new ObjectResult(badRequest.ErrorMessage)
                {
                    StatusCode = StatusCodes.Status400BadRequest
                },
                NotFoundException notFound => new ObjectResult(notFound.ErrorMessage)
                {
                    StatusCode = StatusCodes.Status404NotFound
                },
                _ => new ObjectResult(context.Exception.Message)
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                },
            };

            context.ExceptionHandled = true;

            _logger.LogError(new EventId(context.Exception.HResult), context.Exception, context.Exception.Message);

        }
    }
}

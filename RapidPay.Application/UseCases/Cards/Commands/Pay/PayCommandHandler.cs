using MediatR;
using RapidPay.Abstractions.Services;
using RapidPay.Core.Dtos;

namespace RapidPay.Application.UseCases.Cards.Commands.Pay
{
    internal class PayCommandHandler : IRequestHandler<PayCommand, PaymentDto>
    {
        private readonly IPaymentService _paymentService;

        public PayCommandHandler(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public async Task<PaymentDto> Handle(PayCommand request, CancellationToken cancellationToken)
        {
            return await _paymentService.CreateAsync(request.CardId, request.Amount);
        }
    }
}

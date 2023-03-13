using FluentValidation;

namespace RapidPay.Application.UseCases.Cards.Commands.Pay
{
    public class PayCommandValidator : AbstractValidator<PayCommand>
    {
        public PayCommandValidator()
        {
            RuleFor(payCommand => payCommand.Amount)
                .NotEmpty()
                .GreaterThan(0)
                .WithErrorCode("emptyAmmount")
                .WithMessage("Amount cannot be empty");
        }
    }
}

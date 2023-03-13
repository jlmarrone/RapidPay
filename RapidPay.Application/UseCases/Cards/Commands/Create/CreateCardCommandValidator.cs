using FluentValidation;

namespace RapidPay.Application.UseCases.Cards.Commands.Create
{
    public class CreateCardCommandValidator : AbstractValidator<CreateCardCommand>
    {
        public CreateCardCommandValidator()
        {
            RuleFor(createCardCommand => createCardCommand.Number)
                .NotEmpty()
                .WithErrorCode("emptyNumber")
                .WithMessage("Number cannot be empty");

            RuleFor(createCardCommand => createCardCommand.Number)
                .MaximumLength(15)
                .WithErrorCode("exceededLength")
                .WithMessage("Number cannot have more than 15 digits");
        }
    }
}

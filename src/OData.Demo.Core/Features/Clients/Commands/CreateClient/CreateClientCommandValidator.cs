using FluentValidation;

namespace OData.Demo.Core.Features.Clients.Commands.CreateClient
{
    public class CreateClientCommandValidator : AbstractValidator<CreateClientCommand>
    {
        public CreateClientCommandValidator()
        {
            RuleFor(v => v.Name)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(v => v.Email)
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(255);

            RuleFor(v => v.Phone)
                .NotEmpty()
                .MaximumLength(20);
        }
    }
}
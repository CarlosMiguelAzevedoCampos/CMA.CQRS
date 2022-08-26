using FluentValidation;

namespace CMA.CQRS.Domain.Commands.Model.Validations
{
    public abstract class UserValidation<T> : AbstractValidator<T> where T : NewUserCommand
    {
        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Please, insert your name")
                .Length(2, 150).WithMessage("The name must have between 2 and 150 words!");
        }

        protected void ValidateAddress()
        {
            RuleFor(c => c.Address)
                .NotEmpty().WithMessage("Please, insert your address")
                .Length(2, 10).WithMessage("The address must have between 2 an d 10 words!");
        }

    }
}

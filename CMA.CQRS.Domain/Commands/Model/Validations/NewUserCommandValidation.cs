namespace CMA.CQRS.Domain.Commands.Model.Validations
{
    public class NewUserCommandValidation : UserValidation<NewUserCommand>
    {
        public NewUserCommandValidation()
        {
            ValidateName();
            ValidateAddress();
        }
    }
}

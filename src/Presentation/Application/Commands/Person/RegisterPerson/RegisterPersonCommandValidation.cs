using FluentValidation;
using SistemaVenta.Application;

namespace MsServiceApp
{
    public class RegisterPersonCommandValidation : AbstractValidator<RegisterPersonCommand>
    {
        public RegisterPersonCommandValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(ValidationMessages.ES_REQUERIDO);
            RuleFor(x => x.LastName).NotEmpty().WithMessage(ValidationMessages.ES_REQUERIDO);
            RuleFor(x => x.Email).NotEmpty().WithMessage(ValidationMessages.ES_REQUERIDO);
        }
    }
}
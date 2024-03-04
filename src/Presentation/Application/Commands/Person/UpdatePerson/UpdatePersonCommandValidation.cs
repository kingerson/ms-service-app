using FluentValidation;
using SistemaVenta.Application;

namespace MsServiceApp
{
    public class UpdatePersonCommandValidation : AbstractValidator<UpdatePersonCommand>
    {
        public UpdatePersonCommandValidation()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage(ValidationMessages.ES_REQUERIDO);
            RuleFor(x => x.LastName).NotEmpty().WithMessage(ValidationMessages.ES_REQUERIDO);
            RuleFor(x => x.Email).NotEmpty().WithMessage(ValidationMessages.ES_REQUERIDO);
        }
    }
}
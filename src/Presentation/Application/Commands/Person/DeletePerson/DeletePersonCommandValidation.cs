using FluentValidation;
using SistemaVenta.Application;

namespace MsServiceApp
{
    public class DeletePersonCommandValidation : AbstractValidator<DeletePersonCommand>
    {
        public DeletePersonCommandValidation()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage(ValidationMessages.ES_REQUERIDO);
        }
    }
}
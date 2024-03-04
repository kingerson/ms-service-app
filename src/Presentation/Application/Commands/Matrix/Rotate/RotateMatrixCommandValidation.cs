using FluentValidation;
using SistemaVenta.Application;

namespace MsServiceApp
{
    public class RotateMatrixCommandValidation : AbstractValidator<RotateMatrixCommand>
    {
        public RotateMatrixCommandValidation()
        {
            RuleFor(x => x.Body).NotEmpty().WithMessage(ValidationMessages.ES_REQUERIDO);
        }
    }
}
using FluentValidation;
using SistemaVenta.Application;

namespace MsServiceApp
{
    public class GetPersonByIdQueryValidation : AbstractValidator<GetPersonByIdQuery>
    {
        public GetPersonByIdQueryValidation()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage(ValidationMessages.ES_REQUERIDO);
        }
    }
}
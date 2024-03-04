using MediatR;

namespace MsServiceApp
{
    public sealed record GetPersonByIdQuery(Guid Id) : IRequest<PersonViewModel>;
}
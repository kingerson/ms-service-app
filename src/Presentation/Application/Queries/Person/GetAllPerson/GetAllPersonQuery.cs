using MediatR;

namespace MsServiceApp
{
    public sealed record GetAllPersonQuery() : IRequest<IEnumerable<PersonViewModel>>;
}
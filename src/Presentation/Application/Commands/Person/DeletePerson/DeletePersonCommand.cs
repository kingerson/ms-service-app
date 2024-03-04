using MediatR;

namespace MsServiceApp
{
    public class DeletePersonCommand : IRequest<bool>
    {
        public Guid Id { get; set; } 
    }
}
using MediatR;

namespace MsServiceApp
{
    public class RegisterPersonCommand : IRequest<Guid>
    {
        public string Name { get; set; } 
        public string LastName { get; set; } 
        public string Email { get; set; } 
    }
}
using MediatR;
using Microsoft.EntityFrameworkCore;
using MsServiceApp.Domain;
using MsServiceApp.Infraestructure;

namespace MsServiceApp
{
    public class RegisterPersonCommandHandler : IRequestHandler<RegisterPersonCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        public RegisterPersonCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

        public async Task<Guid> Handle(RegisterPersonCommand request, CancellationToken cancellationToken)
        {
            var person = new Person();
            person.Register(request.Name,request.LastName,request.Email);

            var strategy = _unitOfWork.CreateExecutionStrategy();
            
            await strategy.ExecuteAsync(async () => 
            {
                using (var transaction = await _unitOfWork.BeginTransactionAsync())
                {
                    try
                    {
                        await _unitOfWork.Repository<Person>().Add(person);
                        await _unitOfWork.SaveEntitiesAsync(cancellationToken);
                        await transaction.CommitAsync();
                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();
                        throw new MsServiceException($"Database Error : {ex.Message}");
                    }
                }
            });

            return person.Id;
        }
    }
}
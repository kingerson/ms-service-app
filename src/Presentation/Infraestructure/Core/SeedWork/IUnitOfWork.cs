using Microsoft.EntityFrameworkCore.Storage;
using MsServiceApp.Domain;

namespace MsServiceApp.Infraestructure
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> Repository<T>() where T : Entity;
        Task<int> SaveEntitiesAsync(CancellationToken cancellationToken);
        Task<IDbContextTransaction> BeginTransactionAsync();
        IExecutionStrategy CreateExecutionStrategy();
    }
}
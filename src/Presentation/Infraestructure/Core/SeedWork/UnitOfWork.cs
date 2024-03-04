using Microsoft.EntityFrameworkCore.Storage;
using MsServiceApp.Domain;

namespace MsServiceApp.Infraestructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context) => _context = context ?? throw new ArgumentNullException(nameof(context));
        public async Task<int> SaveEntitiesAsync(CancellationToken cancellationToken) => await _context.SaveChangesAsync(cancellationToken);
        public async Task<IDbContextTransaction> BeginTransactionAsync() => await _context.Database.BeginTransactionAsync();
        public IExecutionStrategy CreateExecutionStrategy() => _context.Database.CreateExecutionStrategy();
        public void Dispose() => _context.Dispose();
        public IRepository<T> Repository<T>() where T : Entity => new Repository<T>(_context);
    }
}
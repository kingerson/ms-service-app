using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using MsServiceApp.Infraestructure;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace MsServiceApp.Infrastructure
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionEntity");

            services.AddScoped<EntityInterceptor>();

            _= services.AddDbContext<ApplicationDbContext>(options => options
                .UseInMemoryDatabase("StoreDb")
                .ConfigureWarnings(warning => warning.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .AddInterceptors(new EntityInterceptor())
            );

            _ = services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            _ = services.AddScoped<IUnitOfWork,UnitOfWork>();

            return services;
        }
    }
}
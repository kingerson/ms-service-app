using System.Diagnostics.CodeAnalysis;

namespace MsServiceApp.Services
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            _ = services.AddScoped<IMemoryCacheService,MemoryCacheService>();

            return services;
        }
    }
}
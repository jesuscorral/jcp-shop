using JCP.Catalog.Application.Interfaces.Repositories;
using JCP.Catalog.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace JCP.Catalog.Infrastructure.Helpers
{
    public static class StartupHelpers
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            //services.AddTransient(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
            services.AddTransient<ICatalogItemRepository, CatalogItemRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}

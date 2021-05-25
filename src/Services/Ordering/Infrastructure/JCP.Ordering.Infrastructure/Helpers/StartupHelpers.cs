using JCP.Ordering.Application.Interface.Repositories;
using JCP.Ordering.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace JCP.Ordering.Infrastructure.Helpers
{
    public static class StartupHelpers
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IOrderRepository, OrderRepository>();
        }
    }
}

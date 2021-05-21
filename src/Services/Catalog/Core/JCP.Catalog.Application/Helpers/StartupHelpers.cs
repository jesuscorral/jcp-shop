using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace JCP.Catalog.Application.Helpers
{
    public static class StartupHelpers
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}

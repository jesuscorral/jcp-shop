using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace JCP.Ordering.Application.Helperes
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

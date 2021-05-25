using JCP.Ordering.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace JCP.Ordering.API.Helpers
{
    public static class StartupHelpers
    {
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            return services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "JCP.Ordering.API", Version = "v1" });
            });
        }

        public static IServiceCollection AddDatabaseContext(this IServiceCollection services, string connectionString)
        {
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddDbContext<OrderingContext>(builder =>
               builder.UseSqlServer(connectionString, sqlOptions => sqlOptions.MigrationsAssembly(migrationsAssembly)));

            return services;
        }
    }
}

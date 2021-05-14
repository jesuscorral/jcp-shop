using JCP.Logger;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using JCP.Catalog.Infrastructure;

namespace JCP.Catalog.API.Helperes
{
    public static class StartupHelpers
    {
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            return services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "JCP.Catalog.API", Version = "v1" });
            });
        }

        public static IServiceCollection AddCustomMeadiatR(this IServiceCollection services)
        {
            return services.AddMediatR(typeof(LogNotification).GetTypeInfo().Assembly);
        }

        public static IServiceCollection AddDatabaseContext(this IServiceCollection services, string connectionString)
        {
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddDbContext<CatalogContext>(builder =>
               builder.UseSqlServer(connectionString, sqlOptions => sqlOptions.MigrationsAssembly(migrationsAssembly)));

            return services;
        }
    }
}

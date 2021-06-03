using CatalogApi;
using JCP.Ordering.BFF.Config;
using JCP.Ordering.BFF.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;

namespace JCP.Ordering.BFF.Helpers
{
    public static class StartupHelpers
    {
        public static IServiceCollection AddGrpcServices(this IServiceCollection services)
        {
            services.AddScoped<ICatalogService, CatalogService>();

            services.AddGrpcClient<Catalog.CatalogClient>((services, options) =>
            {
                var orderingApi = services.GetRequiredService<IOptions<UrlsConfig>>().Value.GrpcCatalog;
                options.Address = new Uri(orderingApi);
            });

            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddHttpClient<IOrderApiClient, OrderApiClient>();

            return services;
        }

        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            return services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "JCP.Ordering.BFF", Version = "v1" });
            });
        }

        public static IServiceCollection AddCustomMvc(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<UrlsConfig>(configuration.GetSection("urls"));

            services.
               AddControllers();

            return services;
        }
    }
}

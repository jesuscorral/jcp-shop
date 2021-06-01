using CatalogApi;
using JCP.Ordering.BFF.Config;
using JCP.Ordering.BFF.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
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
                //options.Address = new Uri(orderingApi);
                options.Address = new Uri("http://catalog-api:80");
            });

            return services;
        }
    }
}

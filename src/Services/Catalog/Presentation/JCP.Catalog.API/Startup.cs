using JCP.Catalog.API.Grpc;
using JCP.Catalog.API.Helpers;
using JCP.Catalog.Application.Helpers;
using JCP.Catalog.Infrastructure.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace JCP.Catalog.API
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = BuildConnectionString();

            services
                .AddGrpc(options =>
                {
                    options.EnableDetailedErrors = true;
                })
                .Services
                .AddCustomMvc()
                .AddDatabaseContext(connectionString)
                .AddCustomSwagger()
                .AddApplicationLayer();

            services.AddRepositories();

            services.Configure<RabbitMqSettings>(_configuration);

            services.AddCustomIntegrations(_configuration);
            services.RegisterEventBus(_configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger()
                .UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "JCP.Catalog.API v1"));


            app.UseRouting();
            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<CatalogService>();
                endpoints.MapDefaultControllerRoute();
                endpoints.MapControllers();

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
                });
            });

            app.ConfigureEventBus();
        }
        private string BuildConnectionString()
        {
            var sqlHostName = Environment.GetEnvironmentVariable("SQL_HOSTNAME") ?? _configuration.GetValue<string>("CatalogDatabaseSettings:hostName");
            var sqlPort = Environment.GetEnvironmentVariable("SQL_PORT") ?? _configuration.GetValue<string>("CatalogDatabaseSettings:port");
            var dbName = _configuration.GetValue<string>("CatalogDatabaseSettings:dbName");
            var sqlUser = _configuration.GetValue<string>("CatalogDatabaseSettings:user");
            var sqlPassword = _configuration.GetValue<string>("CatalogDatabaseSettings:password");

            return $"Server={sqlHostName}, {sqlPort};Initial Catalog={dbName};User ID={sqlUser};Password={sqlPassword}";
        }
    }
}

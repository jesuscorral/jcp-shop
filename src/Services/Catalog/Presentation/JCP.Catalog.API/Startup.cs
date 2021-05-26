using JCP.Catalog.API.Helperes;
using JCP.Catalog.Application.Helpers;
using JCP.Catalog.Infrastructure.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        { 
            var connectionString = BuildConnectionString();

            services.AddControllers()
                .Services
                .AddDatabaseContext(connectionString)
                .AddCustomSwagger()
                .AddApplicationLayer();

            services.AddRepositories();

            services.AddCustomIntegrations(_configuration);
            services.RegisterEventBus(_configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "JCP.Catalog.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
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

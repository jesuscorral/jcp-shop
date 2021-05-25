using JCP.Ordering.API.Helpers;
using JCP.Ordering.Application.Helperes;
using JCP.Ordering.Infrastructure.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace JCP.Ordering.API
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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "JCP.Ordering.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private string BuildConnectionString()
        {
            var sqlHostName = Environment.GetEnvironmentVariable("SQL_HOSTNAME") ?? _configuration.GetValue<string>("ConnectionStrings:jcp-ordering:hostName");
            var sqlPort = Environment.GetEnvironmentVariable("SQL_PORT") ?? _configuration.GetValue<string>("ConnectionStrings:jcp-ordering:port");
            var sqlCatalog = _configuration.GetValue<string>("ConnectionStrings:jcp-ordering:ordering");
            var sqlUser = _configuration.GetValue<string>("ConnectionStrings:jcp-ordering:user");
            var sqlPassword = _configuration.GetValue<string>("ConnectionStrings:jcp-ordering:password");

            return $"Server={sqlHostName}, {sqlPort};Initial Catalog={sqlCatalog};User ID={sqlUser};Password={sqlPassword}";

        }
    }
}
using System.Linq;
using System.Reflection;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JCP.IdentityServer.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // TODO - Move to secrets
            const string connectionString = @"Data Source=.;database=JCP.IdentityServer.API;trusted_connection=yes;";
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddDbContext<JCPIdentityDbContext>(builder =>
                builder.UseSqlServer(connectionString, sqlOptions => sqlOptions.MigrationsAssembly(migrationsAssembly)));
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<JCPIdentityDbContext>();


            //services.AddIdentityServer()
            //        .AddInMemoryClients(Config.GetClients())
            //        .AddInMemoryIdentityResources(Config.IdentityResources)
            //        .AddInMemoryApiResources(Config.GetApiResources())
            //        .AddInMemoryApiScopes(Config.ApiScopes)
            //        .AddTestUsers(Config.TestUsers)
            //        .AddDeveloperSigningCredential();

            // TODO - Move to extension method
            IIdentityServerBuilder ids = services.AddIdentityServer()
               .AddDeveloperSigningCredential();

            // EF client, scope, and persisted grant stores
            ids.AddOperationalStore(options =>
                    options.ConfigureDbContext = builder =>
                        builder.UseSqlServer(connectionString, sqlOptions => sqlOptions.MigrationsAssembly(migrationsAssembly)))
                .AddConfigurationStore(options =>
                    options.ConfigureDbContext = builder =>
                        builder.UseSqlServer(connectionString, sqlOptions => sqlOptions.MigrationsAssembly(migrationsAssembly)));

            // ASP.NET Identity integration
            ids.AddAspNetIdentity<IdentityUser>();

            // Add identity server UI
            services.AddControllersWithViews();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();
            app.UseRouting();

            app.UseIdentityServer();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());
        }
    }
}
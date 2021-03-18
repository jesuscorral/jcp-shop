using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace JCP.IdentityServer.API.Helpers
{
    public static class StartupHelpers
    {
        public static IServiceCollection AddDatabaseContext(this IServiceCollection services, string connectionString)
        {
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddDbContext<JCPIdentityDbContext>(builder =>
               builder.UseSqlServer(connectionString, sqlOptions => sqlOptions.MigrationsAssembly(migrationsAssembly)));

            return services;
        }

        public static IServiceCollection AddIdentityServer2(this IServiceCollection services, string connectionString)
        {
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddEntityFrameworkStores<JCPIdentityDbContext>();

           services.AddIdentityServer()
                   .AddDeveloperSigningCredential()
                   .AddOperationalStore(options =>
                        options.ConfigureDbContext = builder =>
                        builder.UseSqlServer(connectionString, sqlOptions => sqlOptions.MigrationsAssembly(migrationsAssembly)))
                   .AddConfigurationStore(options =>
                        options.ConfigureDbContext = builder =>
                        builder.UseSqlServer(connectionString, sqlOptions => sqlOptions.MigrationsAssembly(migrationsAssembly)))
                   .AddAspNetIdentity<IdentityUser>();

            // Add identity server UI
            services.AddControllersWithViews();

            return services;
        }
    }
}

using Autofac;
using BuildingBlocks.EventBus;
using BuildingBlocks.EventBus.Abstractions;
using BuildingBlocks.EventBus.EventBusRabbitMQ;
using JCP.Ordering.API.IntegrationEvents.EventHandlers;
using JCP.Ordering.API.IntegrationEvents.Events;
using JCP.Ordering.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using RabbitMQ.Client;
using System;
using System.Reflection;

namespace JCP.Ordering.API.Helpers
{
    public static class StartupHelpers
    {
        private const int DefaultRetryCount = 5;

        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            return services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "JCP.Ordering.API", Version = "v1" });
            });
        }

        public static IServiceCollection AddDatabaseContext(this IServiceCollection services, string connectionString, IConfiguration configuration)
        {
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddDbContext<OrderingContext>(builder =>
               builder.UseSqlServer(connectionString, sqlOptions => sqlOptions.MigrationsAssembly(migrationsAssembly)));

            return services;
        }

        public static IServiceCollection AddCustomIntegrations(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IRabbitMQPersistentConnection>(sp =>
            {
                var logger = sp.GetRequiredService<ILogger<DefaultRabbitMQPersistentConnection>>();
                var rabbitMqSettings = sp.GetRequiredService<IOptions<RabbitMqSettings>>().Value;

                var factory = new ConnectionFactory()
                {
                    HostName = Environment.GetEnvironmentVariable("RABBITMQ_HOSTNAME") ?? rabbitMqSettings.Hostname,
                    UserName = Environment.GetEnvironmentVariable("RABBITMQ_DEFAULT_USER") ?? rabbitMqSettings.User,
                    Password = Environment.GetEnvironmentVariable("RABBITMQ_DEFAULT_PASS") ?? rabbitMqSettings.Password,
                    DispatchConsumersAsync = true
                };

                var retryCount = rabbitMqSettings.RetryCount != 0 ? rabbitMqSettings.RetryCount : DefaultRetryCount;

                return new DefaultRabbitMQPersistentConnection(factory, logger, retryCount);
            });

            return services;
        }

        public static IServiceCollection RegisterEventBus(this IServiceCollection services, IConfiguration configuration)
        {
            var subscriptionClientName = configuration.GetValue<string>("SubscriptionClientName");

            services.AddSingleton<IEventBus, EventBusRabbitMQ>(sp =>
            {
                var rabbitMqSettings = sp.GetRequiredService<IOptions<RabbitMqSettings>>().Value;
                var rabbitMQPersistentConnection = sp.GetRequiredService<IRabbitMQPersistentConnection>();
                var iLifetimeScope = sp.GetRequiredService<ILifetimeScope>();
                var logger = sp.GetRequiredService<ILogger<EventBusRabbitMQ>>();
                var eventBusSubcriptionsManager = sp.GetRequiredService<IEventBusSubscriptionsManager>();

                var retryCount = rabbitMqSettings.RetryCount != 0 ? rabbitMqSettings.RetryCount : DefaultRetryCount;

                return new EventBusRabbitMQ(rabbitMQPersistentConnection, logger, iLifetimeScope, eventBusSubcriptionsManager, subscriptionClientName, retryCount);
            });

            services.AddSingleton<IEventBusSubscriptionsManager, InMemoryEventBusSubscriptionsManager>();

            return services;
        }

        public static void ConfigureEventBus(this IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            //eventBus.Subscribe<OrderCreatedIntegrationEvent, IIntegrationEventHandler<OrderCreatedIntegrationEvent>>();

            eventBus.Subscribe<OrderStockConfirmedIntegrationEvent, OrderStockConfirmedIntegrationEventHandler>();
            eventBus.Subscribe<OrderStockRejectedIntegrationEvent, OrderStockRejectedIntegrationEventHandler>();
        }

    }
}

﻿using Autofac;
using BuildingBlocks.EventBus;
using BuildingBlocks.EventBus.Abstractions;
using BuildingBlocks.EventBus.EventBusRabbitMQ;
using JCP.Catalog.API.IntegrationEvents.EventHandling;
using JCP.Catalog.Infrastructure;
using JCP.Ordering.Application.IntegrationEvents;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using RabbitMQ.Client;
using System;
using System.Reflection;

namespace JCP.Catalog.API.Helperes
{
    public static class StartupHelpers
    {
        private const int DefaultRetryCount = 5;

        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            return services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "JCP.Catalog.API", Version = "v1" });
            });
        }

        public static IServiceCollection AddDatabaseContext(this IServiceCollection services, string connectionString)
        {
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddDbContext<CatalogContext>(builder =>
               builder.UseSqlServer(connectionString, sqlOptions => sqlOptions.MigrationsAssembly(migrationsAssembly)));

            return services;
        }

        public static IServiceCollection RegisterEventBus(this IServiceCollection services, IConfiguration configuration)
        {
            var subscriptionClientName = configuration["SubscriptionClientName"];

            services.AddSingleton<IEventBus, EventBusRabbitMQ>(sp =>
            {
                var rabbitMQPersistentConnection = sp.GetRequiredService<IRabbitMQPersistentConnection>();
                var iLifetimeScope = sp.GetRequiredService<ILifetimeScope>();
                var logger = sp.GetRequiredService<ILogger<EventBusRabbitMQ>>();
                var eventBusSubcriptionsManager = sp.GetRequiredService<IEventBusSubscriptionsManager>();

                var retryCount = 5;
                if (!string.IsNullOrEmpty(configuration["EventBusSettings.RetryCount"]))
                {
                    retryCount = int.Parse(configuration["EventBusSettings.RetryCount"]);
                }

                return new EventBusRabbitMQ(rabbitMQPersistentConnection, logger, iLifetimeScope, eventBusSubcriptionsManager, subscriptionClientName, retryCount);
            });

            services.AddSingleton<IEventBusSubscriptionsManager, InMemoryEventBusSubscriptionsManager>();

            services.AddTransient<OrderCreatedIntegrationEventHandler>();

            return services;
        }


        public static IServiceCollection AddCustomIntegrations(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IRabbitMQPersistentConnection>(sp =>
            {
                var logger = sp.GetRequiredService<ILogger<DefaultRabbitMQPersistentConnection>>();

                var factory = new ConnectionFactory()
                {
                    HostName = Environment.GetEnvironmentVariable("RABBITMQ_HOSTNAME") ?? configuration.GetValue<string>("EventBusSettings.Hostname"),
                    UserName = Environment.GetEnvironmentVariable("RABBITMQ_DEFAULT_USER") ?? configuration["EventBusSettings.UserName"],
                    Password = Environment.GetEnvironmentVariable("RABBITMQ_DEFAULT_PASS") ?? configuration["EventBusSettings.Password"],
                    DispatchConsumersAsync = true
                };

                var retryCount = DefaultRetryCount;
                if (!string.IsNullOrEmpty(configuration.GetValue<string>("EventBusSettings.RetryCount")))
                {
                    retryCount = int.Parse(configuration.GetValue<string>("EventBusSettings.RetryCount"));
                }

                return new DefaultRabbitMQPersistentConnection(factory, logger, retryCount);
            });

            return services;
        }

        public static void ConfigureEventBus(this IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            //eventBus.Subscribe<OrderCreatedIntegrationEvent, IIntegrationEventHandler<OrderCreatedIntegrationEvent>>();

            eventBus.Subscribe<OrderCreatedIntegrationEvent, OrderCreatedIntegrationEventHandler>();
        }
    }
}

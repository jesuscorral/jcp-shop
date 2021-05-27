using BuildingBlocks.EventBus.Abstractions;
using BuildingBlocks.EventBus.Events;
using System;
using System.Collections.Generic;
using static BuildingBlocks.EventBus.InMemoryEventBusSubscriptionsManager;

namespace BuildingBlocks.EventBus
{
    public interface IEventBusSubscriptionsManager
    {
        bool IsEmpty { get; }

        event EventHandler<string> OnEventRemoved;

        bool HasSubscriptionsForEvent(string eventName);

        IEnumerable<SubscriptionInfo> GetHandlersForEvent(string eventName);
        void AddSubscription<T, TH>()
           where T : IntegrationEvent
           where TH : IIntegrationEventHandler<T>;

        Type GetEventTypeByName(string eventName);

        void Clear();

        string GetEventKey<T>();
    }
}

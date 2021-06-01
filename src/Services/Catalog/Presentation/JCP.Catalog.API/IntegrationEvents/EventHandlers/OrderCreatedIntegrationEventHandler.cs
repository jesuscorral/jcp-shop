using BuildingBlocks.EventBus.Abstractions;
using JCP.Catalog.API.IntegrationEvents.Events;
using System;
using System.Threading.Tasks;

namespace JCP.Catalog.API.IntegrationEvents.EventHandlers
{
    public class OrderCreatedIntegrationEventHandler : IIntegrationEventHandler<OrderCreatedIntegrationEvent>
    {
        public OrderCreatedIntegrationEventHandler()
        {
        }

        public Task Handle(OrderCreatedIntegrationEvent @event)
        {
            var t = @event;

            // TODO: Manager here the event received.
            throw new NotImplementedException();
        }
    }
}
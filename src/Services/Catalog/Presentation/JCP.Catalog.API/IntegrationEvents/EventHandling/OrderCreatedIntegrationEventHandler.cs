using BuildingBlocks.EventBus.Abstractions;
using JCP.Ordering.Application.IntegrationEvents;
using System;
using System.Threading.Tasks;

namespace JCP.Catalog.API.IntegrationEvents.EventHandling
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

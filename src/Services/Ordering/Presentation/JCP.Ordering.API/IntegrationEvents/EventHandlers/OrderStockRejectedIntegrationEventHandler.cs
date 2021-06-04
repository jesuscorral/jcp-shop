using BuildingBlocks.EventBus.Abstractions;
using JCP.Ordering.API.IntegrationEvents.Events;
using System;
using System.Threading.Tasks;

namespace JCP.Ordering.API.IntegrationEvents.EventHandlers
{
    public class OrderStockRejectedIntegrationEventHandler : IIntegrationEventHandler<OrderStockRejectedIntegrationEvent>
    {
        public Task Handle(OrderStockRejectedIntegrationEvent @event)
        {
            throw new NotImplementedException();
        }
    }
}

using BuildingBlocks.EventBus.Abstractions;
using JCP.Ordering.API.IntegrationEvents.Events;
using System;
using System.Threading.Tasks;

namespace JCP.Ordering.API.IntegrationEvents.EventHandlers
{
    public class OrderStockConfirmedIntegrationEventHandler : IIntegrationEventHandler<OrderStockConfirmedIntegrationEvent>
    {
        public Task Handle(OrderStockConfirmedIntegrationEvent @event)
        {
            throw new NotImplementedException();
        }
    }
}

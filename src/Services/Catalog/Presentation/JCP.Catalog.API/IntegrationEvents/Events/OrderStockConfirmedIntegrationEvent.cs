using BuildingBlocks.EventBus.Events;
using System;

namespace JCP.Catalog.API.IntegrationEvents.Events
{
    public record OrderStockConfirmedIntegrationEvent : IntegrationEvent
    {
        public Guid OrderId { get; set; }

        public OrderStockConfirmedIntegrationEvent(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}

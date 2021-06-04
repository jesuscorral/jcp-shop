using BuildingBlocks.EventBus.Events;
using System;

namespace JCP.Catalog.API.IntegrationEvents.Events
{
    public record OrderStockRejectedIntegrationEvent : IntegrationEvent
    {
        public Guid OrderId { get; set; }

        public OrderStockRejectedIntegrationEvent(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}

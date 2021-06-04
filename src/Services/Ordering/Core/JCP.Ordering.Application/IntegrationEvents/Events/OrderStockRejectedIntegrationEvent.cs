using BuildingBlocks.EventBus.Events;
using System;

namespace JCP.Ordering.Application.IntegrationEvents.Events
{
    public record OrderStockRejectedIntegrationEvent : IntegrationEvent
    {
        public Guid OrderId { get; set; }
    }
}

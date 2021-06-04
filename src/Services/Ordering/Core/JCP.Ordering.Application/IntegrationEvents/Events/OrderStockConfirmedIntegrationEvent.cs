using BuildingBlocks.EventBus.Events;
using System;

namespace JCP.Ordering.Application.IntegrationEvents.Events
{
    public record OrderStockConfirmedIntegrationEvent : IntegrationEvent
    {
        public Guid OrderId { get; set; }
    }
}

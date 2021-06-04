using BuildingBlocks.EventBus.Events;

namespace JCP.Catalog.API.IntegrationEvents.Events
{
    public record OrderStockRejectedIntegrationEvent : IntegrationEvent
    {
        public OrderStockRejectedIntegrationEvent()
        {
        }
    }
}

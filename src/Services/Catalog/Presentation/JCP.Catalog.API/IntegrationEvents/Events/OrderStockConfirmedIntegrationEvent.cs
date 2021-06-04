using BuildingBlocks.EventBus.Events;

namespace JCP.Catalog.API.IntegrationEvents.Events
{
    public record OrderStockConfirmedIntegrationEvent : IntegrationEvent
    {
        public OrderStockConfirmedIntegrationEvent()
        {
        }
    }
}

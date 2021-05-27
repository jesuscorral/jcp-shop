using BuildingBlocks.EventBus.Events;

namespace BuildingBlocks.EventBus.Abstractions
{
    public interface IEventBus
    {
        void Publish(IntegrationEvent @event);

        void Subscribe<T, TH>()
           where T : IntegrationEvent
           where TH : IIntegrationEventHandler<T>;
    }
}

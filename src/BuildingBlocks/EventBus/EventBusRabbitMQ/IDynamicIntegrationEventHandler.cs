using System.Threading.Tasks;

namespace BuildingBlocks.EventBus.EventBusRabbitMQ
{
    public interface IDynamicIntegrationEventHandler
    {
        Task Handle(dynamic eventData);
    }
}
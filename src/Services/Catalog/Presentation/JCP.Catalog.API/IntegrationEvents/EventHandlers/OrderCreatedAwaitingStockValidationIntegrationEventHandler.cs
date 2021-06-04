using BuildingBlocks.EventBus.Abstractions;
using JCP.Catalog.API.IntegrationEvents.Events;
using JCP.Catalog.Application.Features.CatalogItems.Queries.GetById;
using MediatR;
using System;
using System.Threading.Tasks;

namespace JCP.Catalog.API.IntegrationEvents.EventHandlers
{
    public class OrderCreatedAwaitingStockValidationIntegrationEventHandler : IIntegrationEventHandler<OrderCreatedAwaitingStockValidationIntegrationEvent>
    {
        private IMediator _mediator;
        private readonly IEventBus _eventBus;

        public OrderCreatedAwaitingStockValidationIntegrationEventHandler(IMediator mediator,
            IEventBus eventBus)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
        }

        public async Task Handle(OrderCreatedAwaitingStockValidationIntegrationEvent @event)
        {
            // TODO - Validate with orderItems
            // TODO - Cambiar el 1 por los catalogItemId relacionados con la orden.
            var request = new GetByIdQuery(1);
            var result = _mediator.Send(request);
            if (result.Result == null || result.Result.AvailableStock < 0)
            {
                var eventMessage = new OrderStockRejectedIntegrationEvent(Guid.NewGuid());
                _eventBus.Publish(eventMessage);
            }
            else
            {

                var eventMessage = new OrderStockConfirmedIntegrationEvent(Guid.NewGuid());
                _eventBus.Publish(eventMessage);
            }
        }
    }
}
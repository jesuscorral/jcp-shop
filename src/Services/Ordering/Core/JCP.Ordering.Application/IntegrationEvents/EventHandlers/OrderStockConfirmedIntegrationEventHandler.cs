using BuildingBlocks.EventBus.Abstractions;
using JCP.Ordering.Application.Features.Commands.ChangeStatus;
using JCP.Ordering.Application.IntegrationEvents.Events;
using MediatR;
using System;
using System.Threading.Tasks;

namespace JCP.Ordering.Application.IntegrationEvents.EventHandlers
{
    public class OrderStockConfirmedIntegrationEventHandler : IIntegrationEventHandler<OrderStockConfirmedIntegrationEvent>
    {
        private IMediator _mediator;

        public OrderStockConfirmedIntegrationEventHandler(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task Handle(OrderStockConfirmedIntegrationEvent @event)
        {
            var command = new ChangeStatusCommand
            {
                OrderId = @event.Id,
                NewStatus = Catalog.Domain.OrderAggregate.OrderStatus.ConfirmedStockValidation
            };

            var ret = _mediator.Send(command);
        }
    }
}

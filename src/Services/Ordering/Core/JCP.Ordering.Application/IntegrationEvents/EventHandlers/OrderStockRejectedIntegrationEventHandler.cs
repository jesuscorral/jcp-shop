using BuildingBlocks.EventBus.Abstractions;
using JCP.Ordering.Application.Features.Commands.ChangeStatus;
using JCP.Ordering.Application.IntegrationEvents.Events;
using MediatR;
using System;
using System.Threading.Tasks;

namespace JCP.Ordering.Application.IntegrationEvents.EventHandlers
{
    public class OrderStockRejectedIntegrationEventHandler : IIntegrationEventHandler<OrderStockRejectedIntegrationEvent>
    {
        private IMediator _mediator;

        public OrderStockRejectedIntegrationEventHandler(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task Handle(OrderStockRejectedIntegrationEvent @event)
        {
            var command = new ChangeStatusCommand
            {
                OrderId = @event.Id,
                NewStatus = Catalog.Domain.OrderAggregate.OrderStatus.RejectedStockValidation
            };

            var ret = _mediator.Send(command);
        }
    }
}

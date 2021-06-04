using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using JCP.Catalog.Domain.OrderAggregate;
using JCP.Ordering.Application.IntegrationEvents.Events;
using JCP.Ordering.Application.Interface.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace JCP.Ordering.Application.Features.Commands.Create
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderResponse>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        // TODO: Use when has been moved to common project
        //private IUnitOfWork _unitOfWork { get; set; }
        private readonly IEventBus _eventBus;

        public CreateOrderCommandHandler(IOrderRepository orderRepository,
            IMapper mapper,
            IEventBus eventBus)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
        }

        public async Task<CreateOrderResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<Order>(request);
            await _orderRepository.InsertAsync(order);

            // TODO: To improve
            var eventMessage = new OrderCreatedAwaitingStockValidationIntegrationEvent(order.Id, order.Name, order.UserId, order.UserName, order.CardTypeId, order.CardNumber, order.Status);
            _eventBus.Publish(eventMessage);

            return new CreateOrderResponse
            {
                Success = true,
            };
        }
    }
}

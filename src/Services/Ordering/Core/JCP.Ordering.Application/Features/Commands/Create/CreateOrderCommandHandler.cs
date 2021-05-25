using AutoMapper;
using JCP.Catalog.Domain.OrderAggregate;
using JCP.Ordering.Application.Interface.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JCP.Ordering.Application.Features.Commands.Create
{
    public class CreateOrderCommandHandler: IRequestHandler<CreateOrderCommand, CreateOrderResponse>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        // TODO: Use when has been moved to common project
        //private IUnitOfWork _unitOfWork { get; set; }

        public CreateOrderCommandHandler(IOrderRepository orderRepository,
            IMapper mapper)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<CreateOrderResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<Order>(request);
            await _orderRepository.InsertAsync(order);

            return new CreateOrderResponse
            {
                Success = true,
            };
        }
    }
}

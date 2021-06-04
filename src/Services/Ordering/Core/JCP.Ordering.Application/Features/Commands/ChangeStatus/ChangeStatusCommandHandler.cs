using JCP.Ordering.Application.Interface.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace JCP.Ordering.Application.Features.Commands.ChangeStatus
{
    public class ChangeStatusCommandHandler : IRequestHandler<ChangeStatusCommand, bool>
    {
        private readonly IOrderRepository _orderRepository;

        public ChangeStatusCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        }

        public async Task<bool> Handle(ChangeStatusCommand request, CancellationToken cancellationToken)
        {
            var order = _orderRepository.GetById(request.OrderId);
            if (order.Result != null)
            {
                order.Result.Status = request.NewStatus;
            }
            else
            {
                return false;
            }
            return true;

        }
    }
}

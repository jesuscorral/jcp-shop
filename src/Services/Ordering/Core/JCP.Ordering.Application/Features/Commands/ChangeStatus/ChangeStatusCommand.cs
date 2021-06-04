using JCP.Catalog.Domain.OrderAggregate;
using MediatR;
using System;

namespace JCP.Ordering.Application.Features.Commands.ChangeStatus
{
    public class ChangeStatusCommand : IRequest<bool>
    {
        public Guid OrderId { get; set; }
        public OrderStatus NewStatus { get; set; }
    }
}

using JCP.Catalog.Domain.OrderAggregate;
using MediatR;
using System;

namespace JCP.Ordering.Application.Features.Commands.Create
{
    public partial class CreateOrderCommand : IRequest<CreateOrderResponse>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string UserId { get; set; }
        public string UserName { get; set; }
        //public Address address { get; set; }
        public int CardTypeId { get; set; }
        public string CardNumber { get; set; }
        public OrderStatus Status { get; set; }
    }
}

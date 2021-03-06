﻿using JCP.Catalog.Domain.OrderAggregate;
using JCP.Ordering.Application.Interface.Repositories;
using System;
using System.Threading.Tasks;

namespace JCP.Ordering.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderingContext _orderingContext;

        public OrderRepository(OrderingContext orderingContext)
        {
            _orderingContext = orderingContext ?? throw new ArgumentNullException(nameof(orderingContext));
        }

        public async Task<Guid> InsertAsync(Order order)
        {
            await _orderingContext.Orders.AddAsync(order);
            return order.Id;
        }
    }
}

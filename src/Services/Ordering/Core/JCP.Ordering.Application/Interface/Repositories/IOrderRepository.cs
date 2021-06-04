using JCP.Catalog.Domain.OrderAggregate;
using System;
using System.Threading.Tasks;

namespace JCP.Ordering.Application.Interface.Repositories
{
    public interface IOrderRepository
    {
        Task<Guid> InsertAsync(Order order);
        Task<Order> GetById(Guid orderId);
    }
}

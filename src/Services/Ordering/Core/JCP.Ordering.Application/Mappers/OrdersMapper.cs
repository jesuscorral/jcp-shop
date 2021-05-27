using AutoMapper;
using JCP.Catalog.Domain.OrderAggregate;
using JCP.Ordering.Application.Features.Commands.Create;

namespace JCP.Ordering.Application.Mappers
{
    public class OrdersMapper : Profile
    {
        public OrdersMapper()
        {
            CreateMap<CreateOrderCommand, Order>().ReverseMap();
        }
    }
}

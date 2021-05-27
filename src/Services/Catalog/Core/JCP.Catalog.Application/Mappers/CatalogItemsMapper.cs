using AutoMapper;
using JCP.Catalog.Application.Features.CatalogItems.Commands.Create;
using JCP.Catalog.Application.Features.CatalogItems.Queries.GetAll;
using JCP.Catalog.Domain.CatalogItemAggregate;

namespace JCP.Catalog.Application.Mappers
{
    public class CatalogItemsMapper : Profile
    {
        public CatalogItemsMapper()
        {
            CreateMap<CreateCatalogItemCommand, CatalogItem>().ReverseMap();
            CreateMap<CatalogItem, GetAllCatalogItemsResponse>();
        }
    }
}

using AutoMapper;
using JCP.Catalog.Application.Features.Catalogs.Commands.Create;
using JCP.Catalog.Application.Features.Catalogs.Queries.GetAll;
using JCP.Catalog.Domain.CatalogItemAggregate;

namespace JCP.Catalog.Application.Mappers
{
    public class CatalogItemsMapper: Profile
    {
        public CatalogItemsMapper()
        {
            CreateMap<CreateCatalogItemCommand, CatalogItem>().ReverseMap();
            CreateMap<CatalogItem, GetAllCatalogItemsResponse>();
        }
    }
}

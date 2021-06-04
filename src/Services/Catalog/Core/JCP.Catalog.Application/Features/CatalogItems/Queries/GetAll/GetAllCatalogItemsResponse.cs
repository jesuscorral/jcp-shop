using JCP.Catalog.Application.Features.CatalogItems.Queries.Dtos;
using System.Collections.Generic;

namespace JCP.Catalog.Application.Features.CatalogItems.Queries.GetAll
{
    public class GetAllCatalogItemsResponse
    {
        public List<CatalogItemDto> Items { get; set; }
    }
}

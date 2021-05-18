using MediatR;
using System.Collections.Generic;

namespace JCP.Catalog.Application.Features.CatalogItems.Queries.GetAll
{
    public class GetAllCatalogItemsQuery : IRequest<List<GetAllCatalogItemsResponse>>
    {
        public GetAllCatalogItemsQuery()
        {
        }
    }
}

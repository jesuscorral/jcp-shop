using MediatR;
using System.Collections.Generic;

namespace JCP.Catalog.Application.Features.Catalogs.Queries.GetAll
{
    public class GetAllCatalogItemsQuery : IRequest<List<GetAllCatalogItemsResponse>>
    {
        public GetAllCatalogItemsQuery()
        {
        }
    }
}

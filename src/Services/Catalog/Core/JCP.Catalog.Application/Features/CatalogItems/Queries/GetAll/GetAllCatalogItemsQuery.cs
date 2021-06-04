using MediatR;

namespace JCP.Catalog.Application.Features.CatalogItems.Queries.GetAll
{
    public class GetAllCatalogItemsQuery : IRequest<GetAllCatalogItemsResponse>
    {
        public GetAllCatalogItemsQuery()
        {
        }
    }
}

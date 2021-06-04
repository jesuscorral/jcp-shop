using JCP.Catalog.Application.Features.CatalogItems.Queries.Dtos;
using MediatR;

namespace JCP.Catalog.Application.Features.CatalogItems.Queries.GetById
{
    public class GetByIdQuery : IRequest<CatalogItemDto>
    {
        public int CatalogItemId { get; set; }

        public GetByIdQuery(int catalogItem)
        {
            CatalogItemId = catalogItem;
        }
    }
}

using MediatR;

namespace JCP.Catalog.Application.Features.CatalogItems.Commands.Create
{
    public partial class CreateCatalogItemCommand : IRequest<CreateCatalogItemResponse>
    {
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
        public int BrandId { get; set; }
    }
}

namespace JCP.Catalog.Application.Features.CatalogItems.Queries.Dtos
{
    public class CatalogItemDto
    {
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
        public int BrandId { get; set; }
        public int AvailableStock { get; set; }
    }
}

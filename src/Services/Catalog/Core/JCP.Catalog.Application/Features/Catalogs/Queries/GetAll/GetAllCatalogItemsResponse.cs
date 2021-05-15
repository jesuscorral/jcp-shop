namespace JCP.Catalog.Application.Features.Catalogs.Queries.GetAll
{
    public class GetAllCatalogItemsResponse
    {
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
        public int BrandId { get; set; }
    }
}

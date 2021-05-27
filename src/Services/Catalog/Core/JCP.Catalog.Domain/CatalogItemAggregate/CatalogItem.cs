namespace JCP.Catalog.Domain.CatalogItemAggregate
{
    public class CatalogItem : AuditableEntity
    {
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
        public int BrandId { get; set; }
    }
}

namespace JCP.Ordering.BFF.Models
{
    public class CatalogItem
    {
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
        public int BrandId { get; set; }
    }
}

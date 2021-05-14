using JCP.Catalog.Domain.CatalogItemAggregate;
using JCP.Catalog.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace JCP.Catalog.Infrastructure
{
    public class CatalogContext : DbContext
    {
        public const string DEFAULT_SCHEMA = "catalog";

        public DbSet<CatalogItem> CatalogItems { get; set; }

        public CatalogContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CatalogItemEntityTypeConfiguration());
        }
    }
}

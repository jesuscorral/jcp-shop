using JCP.Catalog.Domain.CatalogItemAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JCP.Catalog.Infrastructure.EntityConfigurations
{
    public class CatalogItemEntityTypeConfiguration : IEntityTypeConfiguration<CatalogItem>
    {
        public void Configure(EntityTypeBuilder<CatalogItem> catalogConfiguration)
        {
            catalogConfiguration.ToTable("catalogItems", CatalogContext.DEFAULT_SCHEMA);

            catalogConfiguration.HasKey(b => b.Id);
            catalogConfiguration.Property(b => b.Name)
                .IsRequired();
            catalogConfiguration.Property(b => b.Rate)
                .HasPrecision(4, 2);
        }
    }
}

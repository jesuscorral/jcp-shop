using JCP.Catalog.Domain.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JCP.Ordering.Infrastructure.EntityConfigurations
{
    public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> orderConfiguration)
        {
            orderConfiguration.ToTable("order", OrderingContext.DEFAULT_SCHEMA);

            orderConfiguration.HasKey(b => b.Id);
            orderConfiguration.Property(b => b.Name)
                .IsRequired();
        }
    }
}

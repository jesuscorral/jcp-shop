using JCP.Catalog.Domain.OrderAggregate;
using JCP.Ordering.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace JCP.Ordering.Infrastructure
{
    public class OrderingContext : DbContext
    {
        public const string DEFAULT_SCHEMA = "ordering";

        public DbSet<Order> Orders { get; set; }

        public OrderingContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());
        }
    }
}

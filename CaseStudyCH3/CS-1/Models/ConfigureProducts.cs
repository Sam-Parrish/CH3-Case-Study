using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CS_1.Models
{
    internal class ConfigureProducts : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.HasData(
                new Product { ProductId = 1, ProductCode = "TRN10", Name = "Tournament Master 1.0", Price = (decimal)4.99, ReleaseDate = new DateTime() },
                new Product { ProductId = 2, ProductCode = "LEAG10", Name = "League Scheduler 1.0", Price = (decimal)4.99, ReleaseDate = new DateTime() }
                );
        }
    }
}

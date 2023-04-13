using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CS_1.Models
{
    internal class ConfigureCustomers : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> entity)
        {
            entity.HasData(
                 new Customer { CustomerId = 1, FirstName = "Kaitlyn", LastName = "Anthoni", Address = "120 Buddy Boulevard", City = "San Francisco", State = "California", PostalCode = "62243", Email = "kanthoni@pge.com", Phone = "8005550489", CountryId = 2 }
                );
        }
    }
}

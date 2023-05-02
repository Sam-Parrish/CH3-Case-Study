using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CS_1.Models.DomainModels;

namespace CS_1.Models.DataLayer.Configuration
{
    internal class ConfigureCountries : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> entity)
        {
            entity.HasData(
                new Country { CountryId = 1, Name = "United States of America" },
                new Country { CountryId = 2, Name = "Canada" },
                new Country { CountryId = 3, Name = "United Kingdom" },
                new Country { CountryId = 4, Name = "Japan" },
                new Country { CountryId = 5, Name = "Australia" },
                new Country { CountryId = 6, Name = "Russia" },
                new Country { CountryId = 7, Name = "China" }
                );
        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CS_1.Models.DomainModels;

namespace CS_1.Models.DataLayer.Configuration
{
    internal class ConfigureTechnicians : IEntityTypeConfiguration<Technician>
    {
        public void Configure(EntityTypeBuilder<Technician> entity)
        {
            entity.HasData(
                new Technician { TechnicianId = 1, Name = "Alison Diaz", Email = "alison@sportsprosoftware.com", PhoneNumber = "8005550443" }
                );
        }
    }
}

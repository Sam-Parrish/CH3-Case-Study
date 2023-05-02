using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CS_1.Models.DomainModels;

namespace CS_1.Models.DataLayer.Configuration
{
    internal class ConfigureIncidents : IEntityTypeConfiguration<Incident>
    {
        public void Configure(EntityTypeBuilder<Incident> entity)
        {
            entity.HasData(
                new Incident { IncidentId = 1, CustomerId = 1, ProductId = 1, Title = "Cant run", Description = "The app won't open properly", TechnicianId = 1, DateOpened = new DateTime(), DateClosed = new DateTime() },
                new Incident { IncidentId = 2, CustomerId = 1, ProductId = 1, Title = "Cant run", Description = "The app won't open properly", TechnicianId = 1, DateOpened = new DateTime(), DateClosed = new DateTime() },
                new Incident { IncidentId = 3, CustomerId = 1, ProductId = 1, Title = "Cant run", Description = "The app won't open properly", TechnicianId = 1, DateOpened = new DateTime(), DateClosed = new DateTime() }
                );
        }
    }
}

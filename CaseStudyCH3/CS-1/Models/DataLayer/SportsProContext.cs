using CS_1.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;
using CS_1.Models.DataLayer.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CS_1.Models
{
    public class SportsProContext : IdentityDbContext<User>
    {
        public SportsProContext(DbContextOptions<SportsProContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; } = null!;

        public DbSet<Technician> Technicians { get; set; } = null!;

        public DbSet<Customer> Customers { get; set; } = null!;

        public DbSet<Country> Countries { get; set; } = null!;

        public DbSet<Incident> Incidents { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ConfigureProducts());

            modelBuilder.ApplyConfiguration(new ConfigureTechnicians());

            modelBuilder.ApplyConfiguration(new ConfigureCustomers());

            modelBuilder.ApplyConfiguration(new ConfigureCountries());

            modelBuilder.ApplyConfiguration(new ConfigureIncidents());
        }
    }
}

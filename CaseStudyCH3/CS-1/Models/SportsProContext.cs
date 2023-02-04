using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;

namespace CS_1.Models
{
    public class SportsProContext : DbContext
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
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, ProductCode = "TRN10", Name = "Tournament Master 1.0", Price = (decimal)4.99, ReleaseDate = new DateTime() },
                new Product { ProductId = 2, ProductCode = "LEAG10", Name = "League Scheduler 1.0", Price = (decimal)4.99, ReleaseDate = new DateTime() }
                );

            modelBuilder.Entity<Technician>().HasData(
                new Technician { TechnicianId = 1, Name = "Alison Diaz", Email = "alison@sportsprosoftware.com", PhoneNumber = "8005550443" }
                );

            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, FirstName = "Kaitlyn", LastName = "Anthoni", Address = "120 Buddy Boulevard", City = "San Francisco", State = "California", PostalCode = 09993, Email = "kanthoni@pge.com", Phone = "8005550489", CountryId = "CDA" }
                );

            modelBuilder.Entity<Country>().HasData(
                new Country { CountryId = "USA", Name = "United States of America"},
                new Country { CountryId = "CDA", Name = "Canada" },
                new Country { CountryId = "UNK", Name = "United Kingdom" },
                new Country { CountryId = "JPN", Name = "Japan" },
                new Country { CountryId = "AUS", Name = "Australia" },
                new Country { CountryId = "RSA", Name = "Russia" },
                new Country { CountryId = "CHA", Name = "China" }
                );

            modelBuilder.Entity<Incident>().HasData(
                new Incident { IncidentId = 1, CustomerId = 1, ProductId = 1, Title = "Cant run", Description = "The app won't open properly", TechnicianId = 1, DateOpened = "", DateClosed = "" }
                );
        }
    }
}

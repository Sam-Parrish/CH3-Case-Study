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
            modelBuilder.ApplyConfiguration(new ConfigureProducts());

            modelBuilder.Entity<Technician>().HasData(
                new Technician { TechnicianId = 1, Name = "Alison Diaz", Email = "alison@sportsprosoftware.com", PhoneNumber = "8005550443" }
                );

            modelBuilder.ApplyConfiguration(new ConfigureCustomers());

            modelBuilder.Entity<Country>().HasData(
                new Country { CountryId = 1, Name = "United States of America" },
                new Country { CountryId = 2, Name = "Canada" },
                new Country { CountryId = 3, Name = "United Kingdom" },
                new Country { CountryId = 4, Name = "Japan" },
                new Country { CountryId = 5, Name = "Australia" },
                new Country { CountryId = 6, Name = "Russia" },
                new Country { CountryId = 7, Name = "China" }
                );

            modelBuilder.Entity<Incident>().HasData(
                new Incident { IncidentId = 1, CustomerId = 1, ProductId = 1, Title = "Cant run", Description = "The app won't open properly", TechnicianId = 1, DateOpened = new DateTime(), DateClosed = new DateTime() },
                new Incident { IncidentId = 2, CustomerId = 1, ProductId = 1, Title = "Cant run", Description = "The app won't open properly", TechnicianId = 1, DateOpened = new DateTime(), DateClosed = new DateTime() },
                new Incident { IncidentId = 3, CustomerId = 1, ProductId = 1, Title = "Cant run", Description = "The app won't open properly", TechnicianId = 1, DateOpened = new DateTime(), DateClosed = new DateTime() }
                );
         //   modelBuilder.ApplyConfiguration(new ConfigureRegistrations());
            //modelBuilder.Entity<Product>().HasMany(b => b.Customers).WithMany(b => b.Products).UsingEntity<Dictionary<string, object>>(
            //    "Registration",
            //    ba => ba.HasOne<Customer>()
            //        .WithMany()
            //        .HasForeignKey("CustomerId"),
            //    ba => ba.HasOne<Product>()
            //        .WithMany()
            //        .HasForeignKey("ProductId"),
            //    ba => ba.HasData(
            //        new { ProductId = 1, CustomerId = 1 },
            //        new { ProductId = 2, CustomerId = 2 }
            //    ));
        }
    }
}

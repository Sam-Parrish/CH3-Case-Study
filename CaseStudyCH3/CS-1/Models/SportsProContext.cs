using Microsoft.EntityFrameworkCore;
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
                new Customer { CustomerId = 1, FirstName = "Kaitlyn", LastName = "Anthoni", Email = "kanthoni@pge.com", City = "San Francisco" }
                );

        }
    }
}

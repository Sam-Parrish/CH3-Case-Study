using Microsoft.EntityFrameworkCore;
namespace CS_1.Models
{
	public class ProductContext : DbContext
	{
		public ProductContext(DbContextOptions<ProductContext> options) : base(options)
		{

		}

		public DbSet<Product> Products { get; set; } = null!;

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Product>().HasData(
				new Product { ProductId=1, ProductCode = "TRN10", Name = "Tournament Master 1.0", Price = (decimal)4.99, ReleaseDate = new DateTime()},
				new Product { ProductId = 2, ProductCode = "LEAG10", Name = "League Scheduler 1.0", Price = (decimal)4.99, ReleaseDate = new DateTime()}
				) ;
		}
	}
}

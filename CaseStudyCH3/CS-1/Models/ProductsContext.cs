using Microsoft.EntityFrameworkCore;
namespace CS_1.Models
{
	public class ProductsContext : DbContext
	{
		public ProductsContext(DbContextOptions<ProductsContext> options) : base(options)
		{

		}

		public DbSet<Products> Products { get; set; } = null!;

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Products>().HasData(
				new Products { ProductCode = 00001, Name = "Test product", Price = (decimal)10.00, ReleaseDate = "12/5/2023"},
				new Products { ProductCode = 00002, Name = "Test product", Price = (decimal)15.00, ReleaseDate = "12/5/2023" }
				) ;
		}
	}
}

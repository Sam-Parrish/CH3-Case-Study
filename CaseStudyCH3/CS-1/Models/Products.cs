
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace CS_1.Models
{
	public class Products
	{
		[Key]
		public int ProductCode { get; set; }

		[Required(ErrorMessage = "Please enter a name.")]
		public string Name { get; set; } = string.Empty;

		[Required(ErrorMessage = "Please enter a price.")]
		public decimal? Price { get; set; }

		public string? ReleaseDate { get; set; } = string.Empty;
	}
}

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace CS_1.Models.DomainModels
{
    public class Product
    {
        public Product() => Customers = new HashSet<Customer>();

        public int ProductId { get; set; }
        public string ProductCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a name.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a price.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please enter a release date.")]
        public DateTime ReleaseDate { get; set; } = DateTime.Now;

        public ICollection<Customer> Customers { get; set; }

    }
}

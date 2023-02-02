using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace CS_1.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your name")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your address")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your email")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your home city")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your home state")]
        public string State { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter our home postal code")]
        public int PostalCode { get; set; }

        [Required(ErrorMessage = "Please enter your phone number")]
        public string Phone { get; set; } = string.Empty;
    }
}

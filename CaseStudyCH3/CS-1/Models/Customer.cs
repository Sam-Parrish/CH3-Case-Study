using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc;
using CS_1.Models.Validation;

namespace CS_1.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Please enter your first name")]
        [MinLength(1)]
        [MaxLength(51)]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your last name")]
        [MinLength(1)]
        [MaxLength(51)]
        public string LastName { get; set; } = string.Empty;

        public string FullName => $"{FirstName} {LastName}";

        [Required(ErrorMessage = "Please enter your home address")]
        [MinLength(1)]
        [MaxLength(51)]
        public string Address { get; set; } = string.Empty;

        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [MaxLength(51)]
        [Remote("CheckEmail", "Validation")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Please enter your home city")]
        [MinLength(1)]
        [MaxLength(51)]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your home state")]
        [MinLength(1)]
        [MaxLength(51)]
        public string State { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a valid postal code")]
        [MinLength(1)]
        [MaxLength(21)]
        public string PostalCode { get; set; } = string.Empty;

        [Phone]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$", ErrorMessage = "Phone Number must be in the (xxx) xxx-xxxx format")]
        public string? Phone { get; set; }

        [GreaterThan(0, ErrorMessage = "Please select a country")]
        [Display(Name = "Country")]
        public int CountryId { get; set; }

        [ValidateNever]
        public Country Country { get; set; } = null!;
    }
}

using CS_1.Models.DomainModels;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace CS_1.Models.ViewModels
{
    public class RegistrationViewModel
    {
        public Customer Customer { get; set; } = null!;
        public Product Product { get; set; } = null!;

        public IEnumerable<Product> Products { get; set; } = null!;
    }
}

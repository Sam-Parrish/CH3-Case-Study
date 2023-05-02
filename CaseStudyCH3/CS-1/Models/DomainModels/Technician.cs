using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace CS_1.Models.DomainModels
{
    public class Technician
    {
        public int TechnicianId { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please nnter your email")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your phone number")]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}

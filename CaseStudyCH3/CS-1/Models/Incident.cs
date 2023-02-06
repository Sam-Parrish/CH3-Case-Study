using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
namespace CS_1.Models
{
	public class Incident
	{
		public int IncidentId { get; set; }
		public string DateOpened { get; set; } = string.Empty;

		public string DateClosed { get; set; } = string.Empty;

		[Required(ErrorMessage = "Please enter an incident title")]
		public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select a customer")]
        public int CustomerId { get; set; }

		[ValidateNever]
		public Customer Customer { get; set; } = null!;

        [Required(ErrorMessage = "Please select a product")]
        public int ProductId { get; set; }

        [ValidateNever]
        public Product Product { get; set; } = null!;

		[Required(ErrorMessage = "Please enter a description")]
		public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select a technician")]
        public int TechnicianId { get; set; }

        [ValidateNever]
        public Technician Technician { get; set; } = null!;
	}
}

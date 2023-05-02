using Microsoft.AspNetCore.Identity;
using CS_1.Models.DomainModels;

namespace CS_1.Models
{
	public class UserViewModel
	{
		public IEnumerable<User> Users { get; set; } = null!;
		public IEnumerable<IdentityRole> Roles { get; set; } = null!;
	}
}
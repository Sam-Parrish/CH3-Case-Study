using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS_1.Models.DomainModels
{
    public class User : IdentityUser
    {
        [NotMapped]
        public IList<string> RoleNames { get; set; }
        [NotMapped]
        public string FirstName { get; set; } = string.Empty;
        [NotMapped]
        public string LastName { get; set; } = string.Empty;
    }
}
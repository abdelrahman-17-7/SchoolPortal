using Microsoft.AspNetCore.Identity;

namespace SchoolPortal.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
    }
}
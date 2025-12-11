using Microsoft.AspNetCore.Identity;

namespace Demo_MVC.Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
    }
}

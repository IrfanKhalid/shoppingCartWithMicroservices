using Microsoft.AspNetCore.Identity;

namespace SWT.Services.AuthAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}

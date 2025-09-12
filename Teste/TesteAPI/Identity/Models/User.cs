using Microsoft.AspNetCore.Identity;

namespace Identity.Models
{
    public class User : IdentityUser
    {
        public string Document { get; set; } = string.Empty;
    }
}
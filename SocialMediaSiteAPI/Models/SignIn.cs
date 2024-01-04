using System.ComponentModel.DataAnnotations;

namespace SocialMediaSiteAPI.Models
{
    public class SignIn
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}

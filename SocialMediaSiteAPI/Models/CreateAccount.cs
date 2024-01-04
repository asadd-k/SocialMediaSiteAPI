namespace SocialMediaSiteAPI.Models
{
    public class CreateAccount
    {
        public string FirstName { get; set; } = string.Empty; 

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string Gender { get; set; } = string.Empty;

        public int Day { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

    }
}

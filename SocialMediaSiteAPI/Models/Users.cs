using Microsoft.AspNetCore.Identity;

namespace SocialMediaSiteAPI.Models
{
    public class Users : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Gender { get; set; } = string.Empty;

        public int Day { get; set; }

        public int Month { get; set; }
        
        public int Year { get; set; }

        public List<UserFriends> Friends { get; set; }

        public List<FriendRequests> FriendRequests { get; set; }

        public List<Posts> Posts { get; set; }

        public byte[] ?ProfilePic { get; set; }
    }

    public class ProfilePicModel
    {
        public string UserName { get; set; }

        public IFormFile ProfilePic { get; set; }
    }

}

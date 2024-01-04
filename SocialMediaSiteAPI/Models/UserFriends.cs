using System.ComponentModel.DataAnnotations;

namespace SocialMediaSiteAPI.Models
{
    public class UserFriends
    {
        public int ID { get; set;}
        public string Name { get; set; }
        public string UserName { get; set; }
        public string FriendName { get; set;}
        public string FriendUserName { get; set; }
        public Users User { get; set; }
    }

    public class UserFriendsDTO
    {
        public string Name { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string FriendName { get; set; } = string.Empty;
        public string FriendUserName { get; set; } = string.Empty;
        public byte[] ProfilePic { get; set; }
    }

}

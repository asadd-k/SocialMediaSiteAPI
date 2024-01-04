namespace SocialMediaSiteAPI.Models
{
    public class FriendRequests
    {
        public int ID { get; set; }

        public Users User { get; set; }

        public string UserName { get; set; }

        public string UserNameToAdd { get; set; }

        public bool Accepted { get; set; }
    }

    public class FriendRequestDTO
    {
        public string UserName { get; set; }

        public string UserNameToAdd { get; set; }

        public bool Accepted { get; set; }
    }



}

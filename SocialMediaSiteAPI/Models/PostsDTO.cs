namespace SocialMediaSiteAPI.Models
{
    public class PostsDTO
    {
        
        public string UserName { get; set; } = string.Empty;
        public byte[] ProfilePic {get; set;}
        public string PostText { get; set; } = string.Empty; 
        public byte[] PostImage { get; set; }
        public byte[] PostVideo { get; set; }

    }

    public class PostModel
    {
        public string? username { get; set; }
        
        public string? text { get; set; } 

        public IFormFile? image {get; set;} 
        
        public IFormFile? video {get; set;}
    }
}

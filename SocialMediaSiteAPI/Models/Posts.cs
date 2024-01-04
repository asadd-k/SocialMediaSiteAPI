namespace SocialMediaSiteAPI.Models
{
    public class Posts
    {
        public int Id { get; set; }

        public Users User { get; set; }   
        
        public string PostText { get; set; } = string.Empty;

        public byte[] PostImage { get; set; }

        public byte[] PostVideo { get; set; }

        public List<PostImagesVideos> ImagesVideos { get; set; }
      
    }
}

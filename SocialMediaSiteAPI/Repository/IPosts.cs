using SocialMediaSiteAPI.Models;

namespace SocialMediaSiteAPI.Repository
{
    public interface IPosts 
    {
        public void AddPostText(string username, string PostText);

        public void AddPosts(string username ,string text, IFormFile image, IFormFile video);

        public List<PostsDTO> GetUserPost(string username);

        public List<PostsDTO> GetFriendsPosts(string username);

        //public void AddPostImageVideo(List<IFormFile> images, string username);
    }
}

using Microsoft.EntityFrameworkCore;
using SocialMediaSiteAPI.Models;

namespace SocialMediaSiteAPI.Repository
{
    public class PostsRepo : IPosts
    {
        private readonly AppDbContext _context;

        public PostsRepo(AppDbContext context)
        {
            _context=context;
        }

        public void AddPosts(string username,string text, IFormFile image, IFormFile video)
        {
            var User = _context.Users.FirstOrDefault(u => u.UserName == username);

            if (User == null)
            {
                return;
            }
            if (User.Posts == null)
            {
                User.Posts = new List<Posts>();
            }

            Posts post = new Posts() 
            {
                PostText = text,
            };    
            if (image !=null && image.Length > 0)
            {
                byte[] imagefilebyte = new byte[image.Length];
                MemoryStream stream = new MemoryStream();
                image.CopyTo(stream);
                imagefilebyte = stream.ToArray();
                post.PostImage = imagefilebyte;
            }
            else
            {
                post.PostImage = new byte[0];
            }

            if (video != null && video.Length > 0)
            {
                byte[] videofilebytes = new byte[video.Length] ;
                using (MemoryStream stream = new MemoryStream()) 
                {
                    video.CopyTo(stream);
                    videofilebytes= stream.ToArray();
                    post.PostVideo = videofilebytes;
                }
            }
            else
            {
                post.PostVideo= new byte[0];    
            }
            User.Posts.Add(post);
            _context.Users.Update(User);
            _context.SaveChanges();
        }

        public void AddPostText(string username, string PostText)
        {
            var User = _context.Users.FirstOrDefault(u => u.UserName == username);

            if (User == null)
            {
                throw new InvalidOperationException("No Such Users exist");
            }

            if (User.Posts == null)
            {
                User.Posts = new List<Posts>();
            }

            User.Posts.Add(new Posts
            {
                PostText = PostText,
            });
            _context.Users.Update(User);
            _context.SaveChanges();
        }

        public List<PostsDTO> GetUserPost(string username)
        {
            var posts = _context.Posts
                .Where(p => p.User.UserName == username)
                .Select(p => new PostsDTO
                {
                    UserName = p.User.UserName,
                    ProfilePic = p.User.ProfilePic,
                    PostText = p.PostText,
                    PostImage = p.PostImage,
                    PostVideo = p.PostVideo,
                })
                .ToList();

            return posts;
        }

        public List<UserFriends> GetAllFriends(string currentuser)
        {
            var User = _context.Users.Include(u => u.Friends).FirstOrDefault(x => x.UserName == currentuser);

            if (User == null)
            {
                throw new Exception();
            }

            return User.Friends;
        }



        public List<PostsDTO> GetFriendsPosts(string username)
        {
            List<PostsDTO> AllPosts = new List<PostsDTO>();
            List<UserFriends> friends = GetAllFriends(username);

            foreach (var friend in friends)
            {
                var user = _context.Users.Include(x => x.Posts).FirstOrDefault(x => x.UserName == friend.UserName);

                if (user != null)
                {
                    List<Posts> friendPosts = user.Posts.ToList();
                    foreach (var post in friendPosts)
                    {
                        AllPosts.Add(new PostsDTO {UserName = post.User.UserName, 
                        ProfilePic = post.User.ProfilePic ,  PostText = post.PostText ,
                        PostVideo = post.PostVideo, PostImage = post.PostImage});
                    }

                }
            }
            return AllPosts;
        }



        //public void AddPostImageVideo(List<IFormFile> files, string username)
        //{
        //    var User = _context.Users.FirstOrDefault(u => u.UserName == username); 

        //    if (User == null ) 
        //    {
        //        return; 
        //    }

        //    PostImagesVideos postImages = new PostImagesVideos() { Username = username };



        //    foreach(var file in files)
        //    {
        //        byte[] filebyte = new byte[file.Length];
        //        MemoryStream stream = new MemoryStream();
        //        file.CopyTo(stream);
        //        filebyte = stream.ToArray();

        //        postImages.Bytes = filebyte; 

        //    }
        //}

        //public void AddPostImageVideo(List<IFormFile> files, string username)
        //{
        //    string dataPath = Path.Combine("UserData", username);

        //    if (!Directory.Exists(dataPath))
        //    {
        //        Directory.CreateDirectory(dataPath);
        //    }

        //    foreach (var file in files)
        //    {
        //        if (file.Length > 0)
        //        {
        //            string filePath = Path.Combine(dataPath, file.FileName);

        //            using (var stream = new FileStream(filePath, FileMode.Create))
        //            {
        //                file.CopyTo(stream);
        //            }
        //        }
        //    }
        //}

    }
}

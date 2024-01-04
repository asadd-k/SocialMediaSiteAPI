using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMediaSiteAPI.Models;
using SocialMediaSiteAPI.Repository;

namespace SocialMediaSiteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPosts repo;

        public PostsController(IPosts _repo)
        {
            repo = _repo;
        }

        [HttpPost("AddPosts")]
        [Authorize]
        public IActionResult AddNewPosts([FromForm] PostModel post)
        {
            repo.AddPosts(post.username, post.text, post.image, post.video);
            return Ok();
        }

        [HttpGet("GetFriendsPosts")]
        [Authorize]
        public IActionResult GetFriendPost(string username)
        {
            return Ok(repo.GetFriendsPosts(username));
        }

        [HttpGet("GetUserPosts")]
        [Authorize]
        public IActionResult GetUsersPosts(string username)
        {
            return Ok(repo.GetUserPost(username));
        }

    }
}

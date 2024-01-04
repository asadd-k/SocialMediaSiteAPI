using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMediaSiteAPI.Models;
using SocialMediaSiteAPI.Repository;

namespace SocialMediaSiteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepo repo;

        public UsersController(IUsersRepo users)
        {
            repo = users;
        }

        [HttpPost("CreateAccount")]
        public async Task<IActionResult> CreateAccount([FromBody]CreateAccount user)
        {
            var result = await repo.CreateAccount(user);

            try
            {
                return Ok(result);
            }
            catch
            {
                return Unauthorized();
            }
        }


        [HttpPost("SignIn")]
        public async  Task<IActionResult> SignIn([FromBody]SignIn signIn)
        {
            var result = await repo.Login(signIn);
            return Ok(result); 
           
        }

        [HttpGet("GetAllAccounts")]
        [Authorize]
        public IActionResult GetAll()
        {
            return Ok(repo.GetAll()); 
        }

        [HttpGet("GetFriends")]
        //[Authorize]
        public IActionResult GetFriends(string username)
        {
            var result = repo.GetAllFriends(username);
            return Ok(result);
        }

        [HttpGet("GetUserDetails")]
        //[Authorize]
        public IActionResult GetUser(string username)
        {
            var result =  repo.GetUser(username);
            return Ok(result);
        }

        [HttpPost("SendRequest")]
        //[Authorize]
        public IActionResult SendRequest([FromForm] FriendRequestDTO requestDTO) 
        {
            repo.SendRequest(requestDTO);
            return Ok(); 
        }

        [HttpPost("AcceptRequest")]
        //[Authorize]
        public IActionResult AcceptRequest([FromForm] FriendRequestDTO requestDTO)
        {
            repo.AcceptRequest(requestDTO);
            return Ok();
        }

        [HttpGet("PendingRequests")]
        public IActionResult PendingRequests(string username)
        {
            var result = repo.PendingRequests(username);
            if (result == null) { return NoContent();  }
            return Ok(result);
        }

        [HttpPost("CheckFriend")]
        public IActionResult CheckFriend(string curr, string FriendToCheck)
        {
            var result = repo.CheckFriend(curr, FriendToCheck);
            return Ok(result);  
        }


        [HttpGet("Search")]
        public IActionResult Search(string searchTerm)
        {
            var result = repo.SearchUsers(searchTerm);
            if (result.Count == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(result); 
            }
        }

        [HttpPost("SetProfilePic")]
        [Authorize]
        public IActionResult SetProfilePic([FromForm] ProfilePicModel profilePicModel) 
        {
            repo.SetProfilePic(profilePicModel.UserName, profilePicModel.ProfilePic);
            return Ok();
        } 


        // [HttpPost("SendMessages")]
        //// [Authorize]
        // public IActionResult SendMessage(string current, string friend, string msg)
        // {
        //     var result = repo.SendMessages(current, friend, msg);
        //     return Ok(result);
        // }
    }
}

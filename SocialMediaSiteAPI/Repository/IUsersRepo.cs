using Microsoft.AspNetCore.Identity;
using SocialMediaSiteAPI.Migrations;
using SocialMediaSiteAPI.Models;

namespace SocialMediaSiteAPI.Repository
{
    public interface IUsersRepo
    {
        public Task<IdentityResult> CreateAccount(CreateAccount user);

        public Task<string> Login(SignIn login);
        
        public List<Users> GetAll();

        public Users GetUser(string username);

        public void SendRequest(FriendRequestDTO requestDTO);

        public void AcceptRequest(FriendRequestDTO requestDTO);

        public List<FriendRequestDTO> PendingRequests(string username);

        public List<UserFriendsDTO> GetAllFriends(string currentuser); 

        public bool CheckFriend(string curruser, string friend);

        public List<Users> SearchUsers(string searchTerm);

        //public string SendMessages(string currentuser, string friendtomsg, string Message);

        public void SetProfilePic(string username, IFormFile file); 

        
      
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SocialMediaSiteAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SocialMediaSiteAPI.Repository
{
    public class UsersRepo : IUsersRepo
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<Users> userManager;
        private readonly SignInManager<Users> loginmanager;
        private readonly AppDbContext _context; 

        public UsersRepo(IConfiguration configuration, UserManager<Users> usermgr, SignInManager<Users> _login, AppDbContext context)
        {
            _configuration = configuration;
            userManager = usermgr;
            loginmanager = _login;
            _context=context;
        }

        public async Task<IdentityResult> CreateAccount(CreateAccount user)
        {
       
            string[] parts = user.Email.Split('@');
            var newuser = new Users()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                UserName = parts[0].ToLower(),
                Gender = user.Gender,
                Day = user.Day,
                Month = user.Month, 
                Year = user.Year
            }; 
            
            var result =  await userManager.CreateAsync(newuser, user.Password);

            if (result.Succeeded)
            {
                return result;
            }
            else
            {
                return IdentityResult.Failed(result.Errors.ToArray());
            }
        }

        public async Task<string> Login(SignIn login)
        {
            var user = await userManager.FindByEmailAsync(login.Email);
            if (user != null)
            {
                var result = await loginmanager.PasswordSignInAsync(user.UserName!, login.Password, false, false);
                if (result.Succeeded)
                {
                    var authCliams = new List<Claim>
            {
                new Claim(ClaimTypes.Name, login.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

                    var authsignkey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]));

                    var token = new JwtSecurityToken(
                        issuer: _configuration["JWT:ValidIssuer"],
                        audience: _configuration["JWT:ValidAudience"],
                        expires: DateTime.Now.AddDays(1),
                        claims: authCliams,
                        signingCredentials: new SigningCredentials(authsignkey, SecurityAlgorithms.HmacSha256Signature)
                        );

                    return new JwtSecurityTokenHandler().WriteToken(token);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return "User not found"; 
            }
        }

        public List<Users> GetAll()
        {
            var result = _context.Users.ToList();
            return result; 
        }

        public Users GetUser(string username)
        {
            var user = _context.Users.FirstOrDefault(un => un.UserName == username);
            return user!;
        }

        public void SendRequest(FriendRequestDTO requestDTO)
        {
            var User = _context.Users.FirstOrDefault(u => u.UserName == requestDTO.UserName);

            if (User == null)
            {
                return;
            }

            if (User.FriendRequests == null)
            {
                User.FriendRequests = new List<FriendRequests> { };
            }

            FriendRequests request = new FriendRequests()
            {
                UserName = requestDTO.UserNameToAdd,
                UserNameToAdd = requestDTO.UserName,
                Accepted = false
            };

            User.FriendRequests.Add(request);
            _context.Users.Update(User);
            _context.SaveChanges();
        }

        public void AcceptRequest(FriendRequestDTO requestDTO)
        {
            var request = _context.FriendRequests.FirstOrDefault(
                u => u.UserName == requestDTO.UserName && 
                u.UserNameToAdd == requestDTO.UserNameToAdd && 
                u.Accepted == false);

            if (request == null)
            {
                return; 
            }

            request.Accepted = true;
            AddFriend(requestDTO.UserName, requestDTO.UserNameToAdd);

            AddFriend(requestDTO.UserNameToAdd, requestDTO.UserName);
            _context.FriendRequests.Update(request);
            _context.SaveChanges();
        }

        public List<FriendRequestDTO> PendingRequests(string username)
        {
            var request = _context.FriendRequests.Where(u => u.UserName == username && u.Accepted == false).ToList();

            if (request == null)
            {
                return null;
            }
   
            List<FriendRequestDTO> friendRequestDTOs= new List<FriendRequestDTO>();

            foreach (var req in request)
            {
                friendRequestDTOs.Add(new FriendRequestDTO() 
                {
                    UserName = req.UserName,
                    UserNameToAdd = req.UserNameToAdd,
                    Accepted = req.Accepted,
                });
            }

            return friendRequestDTOs; 

        }

        public void AddFriend(string currentuser, string newuser)
        {
            var CurrentUser = _context.Users.FirstOrDefault(un => un.UserName == currentuser);

            var AddedUser = _context.Users.FirstOrDefault(un => un.UserName == newuser);

            if (CurrentUser == null || AddedUser == null)
            {
                throw new InvalidOperationException("No Such Users exist");
            }

            if (CurrentUser.Friends == null)
            {
                CurrentUser.Friends = new List<UserFriends>();
            }

            CurrentUser.Friends.Add(new UserFriends 
            {
                Name = AddedUser.FirstName + AddedUser.LastName,
                UserName =newuser,
                FriendName= CurrentUser.FirstName+CurrentUser.LastName ,
                FriendUserName = currentuser,
                User = AddedUser
            });
            _context.Users.Update(CurrentUser);
            _context.SaveChanges();
        }

        // public List<UserFriendsDTO> GetAllFriends(string currentuser)
        // {
        //     var User = _context.Users
        //         .Include(u => u.Friends)
        //         .FirstOrDefault(x => x.UserName == currentuser);

        //     if (User == null)
        //     {
        //         return new List<UserFriendsDTO>();
        //     }

        //     List<UserFriendsDTO> UserFriends = User.Friends.Select(friend => new UserFriendsDTO
        //     {
        //         Name = friend.Name,
        //         UserName = friend.UserName,
        //         FriendName = friend.FriendName,
        //         FriendUserName = friend.FriendUserName,
        //         ProfilePic = friend.User.ProfilePic 
        //     }).ToList();

        //     return UserFriends;
        // }
        public List<UserFriendsDTO> GetAllFriends(string currentuser)
        {
            var User = _context.Users
                .Include(u => u.Friends)
                .FirstOrDefault(x => x.UserName == currentuser);

            if (User == null)
            {
                return new List<UserFriendsDTO>();
            }

            List<UserFriendsDTO> UserFriends = User.Friends.Select(friend => new UserFriendsDTO
            {
                Name = friend.Name,
                UserName = friend.UserName,
                FriendName = friend.FriendName,
                FriendUserName = friend.FriendUserName,
                 
            }).ToList();

            return UserFriends;
        }


        public bool CheckFriend(string curruser, string friendToCheck)
        {
            var AllFriends = GetAllFriends(curruser);

            foreach(var friend in AllFriends)
            {
                if (friend.UserName == friendToCheck)
                {
                    return true;
                }
            }
            return false;
        }

        public List<Users> SearchUsers(string searchTerm)
        {
            if (searchTerm ==null)
            {
                return null; 
            }
            return _context.Users.Where(u => u.UserName.Contains(searchTerm) || u.FirstName.Contains(searchTerm) || u.LastName.Contains(searchTerm) || u.Email.Contains(searchTerm)).ToList();
        }

        public void SetProfilePic(string username, IFormFile file)
        {
            var User = _context.Users.FirstOrDefault(un => un.UserName == username);
            if (User == null)
            {
                return;
            }

            byte[] filebyte = new byte[file.Length];
            MemoryStream stream = new MemoryStream();
            file.CopyTo(stream);
            filebyte = stream.ToArray();

            User.ProfilePic = filebyte;
            _context.Users.Update(User);
            _context.SaveChanges();

        }

        //public string SendMessages(string currentuser, string friendtomsg, string Message)
        //{
        //    var allFriends = GetAllFriends(currentuser);
        //    var FriendToMsg = allFriends.Find(usr => usr.UserName == friendtomsg);

        //    if (FriendToMsg == null)
        //    {
        //        //current user does not have that friend
        //        return "No friend of that username"; 
        //    }

        //    else
        //    {
        //        return $"Message has been sent to {FriendToMsg.Name}, \n\n{Message}";
        //    }
        //}




    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialMediaSiteAPI.Models;

namespace SocialMediaSiteAPI
{
    public class AppDbContext : IdentityDbContext<Users>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
                
        }

        public DbSet<UserFriends> UserFriends { get; set; }

        public DbSet<Posts> Posts { get; set; } 

        public DbSet<FriendRequests> FriendRequests { get; set; }
    }
}

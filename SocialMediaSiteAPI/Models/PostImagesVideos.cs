using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SocialMediaSiteAPI.Models
{
    public class PostImagesVideos
    {
        public int ID { get; set; }

        public Posts Posts { get; set; }

        public string Username { get; set; }

        public byte[] Bytes { get; set; }
    }
}

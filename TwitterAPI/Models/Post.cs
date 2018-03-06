using System;
namespace TwitterAPI.Models
{
    public class Post
    {
        public int id { get; set; }
        public string text { get; set; }

        public int userId { get; set; }
        public User user { get; set; }

        public Post()
        {
        }
    }
}


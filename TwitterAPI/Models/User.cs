using System;
using System.Collections.Generic;

namespace TwitterAPI.Models
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        

        public List<Post> posts { get; set; }

        public User()
        {
        }
    }
}

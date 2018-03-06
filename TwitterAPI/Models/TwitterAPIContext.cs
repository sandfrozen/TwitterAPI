using System;
using Microsoft.EntityFrameworkCore;

namespace TwitterAPI.Models
{
    public class TwitterAPIContext : DbContext
    {

        public TwitterAPIContext(DbContextOptions<TwitterAPIContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}

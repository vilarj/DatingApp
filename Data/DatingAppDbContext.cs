using DatingApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Data
{
    public class DatingAppDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
    }
}
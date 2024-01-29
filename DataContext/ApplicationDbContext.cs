using Microsoft.EntityFrameworkCore;
using TravelDeskAPI.Models;

namespace TravelDeskAPI.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Department> Department { get; set; }
    }
}

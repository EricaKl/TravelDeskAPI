using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using TravelDeskAPI.Models;

namespace TravelDeskAPI.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

   
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Role>().HasData(
                new() { RoleId = 1, RoleName = "Admin" },
                new() { RoleId = 2, RoleName = "HRAdmin" },
                new() { RoleId = 3, RoleName = "Employee" },
                new() { RoleId = 4, RoleName = "Manager" }
           );

            modelBuilder.Entity<Department>().HasData(
               new() { DeptId = 1, DepartmentName = "HR" },
               new() { DeptId = 2, DepartmentName = "Admin" },
               new() { DeptId = 3, DepartmentName = "IT" },
               new() { DeptId = 4, DepartmentName = "Sales" }
          );

        }

    
    public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Department> Department { get; set; }
    }
}

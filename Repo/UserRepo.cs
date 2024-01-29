using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using TravelDeskAPI.DataContext;
using TravelDeskAPI.IRepo;
using TravelDeskAPI.Models;

namespace TravelDeskAPI.Repo
{
    public class UserRepo:IUserRepo
    {
        ApplicationDbContext _context;
        public UserRepo(ApplicationDbContext context)
        {
            _context = context;

        }

        public List<User> GetAllUsers()
        {
            var data = _context.User.Where(x=>x.IsActive==true).ToList();
            return data;
        }

        public User GetUserById(int id)
        {
            var data = _context.User.Where(x=>x.IsActive==true &&  x.UserId == id).FirstOrDefault();
            return data;

        }

        public void AddUser(User user)
        {
            //var data = new User
            //{
            //    //UserId = user.UserId,
            //    FirstName = user.FirstName,
            //    LastName = user.LastName,
            //    Email = user.Email,
            //    Password = user.Password,
            //    Address = user.Address, 
            //    MobileNumber = user.MobileNumber,

            //}
          
            _context.User.Add(user);
            _context.SaveChanges();
        }

        //public void AddUser(User user)
        //{
            
        //    _context.User.Add(user);
        //    _context.SaveChanges();

        //}
    }
}

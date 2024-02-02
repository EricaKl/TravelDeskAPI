using System.Web.Http;
using TravelDeskAPI.DataContext;
using TravelDeskAPI.IRepo;
using TravelDeskAPI.Models;
using TravelDeskAPI.ViewModel;

namespace TravelDeskAPI.Repo
{
    public class LoginRepo : ILoginRepo
    {
        ApplicationDbContext _context;

        public LoginRepo(ApplicationDbContext context)
        {
            _context = context;
        }

       
        public bool Login(LoginViewModel user)
        {
            var email = _context.User.Where(x => x.Email == user.Email).SingleOrDefault();
            if(email!=null)
            {
                var password = _context.User.Where(x=>x.Password == user.Password).SingleOrDefault();
                if(password!=null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
               
            }
            else
            {
                return false;
            }

        }
    }
}

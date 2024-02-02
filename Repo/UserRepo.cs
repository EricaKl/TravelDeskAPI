
using TravelDeskAPI.DataContext;
using TravelDeskAPI.IRepo;
using TravelDeskAPI.Models;
using TravelDeskAPI.ViewModel;

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

        public int GetRole(LoginViewModel user)
        {
            var roleName = (from role in _context.User

                            where user.Email == role.Email
                            select role.RoleId).FirstOrDefault();
            return roleName;
        }

        public string GetRoleName(int roleId)
        {
            var roleName = (from role in _context.Role

                            where role.RoleId == roleId
                            select role.RoleName).SingleOrDefault();
            return roleName;
        }
        public void AddUser(User user)
        { 
            _context.User.Add(user);
            _context.SaveChanges();
        }

        public int UpdateUser(User user, int id )
        {
            var data = _context.User.Where(e => e.UserId == id && e.IsActive == true).SingleOrDefault();
            if(data == null)
            {
                return 0;
            }
            else
            {
                data.FirstName = user.FirstName; 
                data.LastName = user.LastName;
                data.Email = user.Email;
                data.Password = user.Password;
                data.Address = user.Address;
                data.MobileNumber = user.MobileNumber;
                data.CreateBy = user.CreateBy;
                data.CreatedOn = user.CreatedOn;
                data.UpdateBy = user.UpdateBy;
                data.UpdatedOn = user.UpdatedOn;
                data.IsActive = user.IsActive;  
                //data.Department = user.Department;
                //data.Role = user.Role;
                data.RoleId = user.RoleId;
                data.ManagerId = user.ManagerId;
                //data.user = user;
                data.DepartmentId = user.DepartmentId;
   
                _context.User.Update(data);
                _context.SaveChanges();
                return 1;

            }
          
        }

        public bool DeleteUser(int userid)
        {
           
                var data = _context.User.Where(x=>x.UserId == userid && x.IsActive == true).SingleOrDefault();
                if(data == null)
                {
                    return false;
                }
                else
                {
                    data.IsActive = false;
                    _context.User.Update(data);
                _context.SaveChanges();
                    return true;
                }
            
        }
        
        public List<Role> GetRoles()
        {
             var data  = _context.Role.Where(x=>(x.RoleName.ToLower()=="employee" || x.RoleName.ToLower() == "manager" )&& x.IsActive==true).ToList();
             return data;
        }

      
        public List<ManagerViewModel> GetManagers()  
        {
           
            List<ManagerViewModel> managerNames = (from p in _context.User
                                join e in _context.Role on p.RoleId equals e.RoleId
                                where e.RoleName.Equals("manager") 
                                select new ManagerViewModel()
                                {
                                     UserId = p.UserId ,
                                    FirstName = p.FirstName}
                
                               ).ToList();
            return managerNames;
           
        }

        public List<Department> GetDepartments()
        {
            var data = _context.Department.ToList();
            return data;
        }

    }
}

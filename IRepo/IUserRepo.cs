using TravelDeskAPI.Models;
using TravelDeskAPI.ViewModel;

namespace TravelDeskAPI.IRepo
{
    public interface IUserRepo
    {
        List<User> GetAllUsers();
        User GetUserById(int id);
        void AddUser(User user);
        int UpdateUser(User user, int id);
        bool DeleteUser(int id);
        List<Role> GetRoles();

        List<ManagerViewModel> GetManagers();
        List<Department> GetDepartments();
        public int GetRole(LoginViewModel user);


        public string GetRoleName(int roleId);
    }
}

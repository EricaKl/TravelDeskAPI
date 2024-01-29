using TravelDeskAPI.Models;

namespace TravelDeskAPI.IRepo
{
    public interface IUserRepo
    {
        List<User> GetAllUsers();
        User GetUserById(int id);
        void AddUser(User user);
        //void UpdateUser(User user);
        //bool DeleteUser(int id);
    }
}

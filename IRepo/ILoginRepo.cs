using TravelDeskAPI.Models;
using TravelDeskAPI.ViewModel;

namespace TravelDeskAPI.IRepo
{
    public interface ILoginRepo
    {
        bool Login(LoginViewModel user);
    }
}

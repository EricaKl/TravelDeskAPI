using System.ComponentModel.DataAnnotations;

namespace TravelDeskAPI.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

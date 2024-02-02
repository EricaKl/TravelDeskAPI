using System.ComponentModel.DataAnnotations;
using TravelDeskAPI.DataContext;
using TravelDeskAPI.Models;

namespace TravelDeskAPI.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public int CreateBy { get; set; }
        public int? UpdateBy { get; set; } = null;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<User> Users { get; set;}

      

    }


 
}


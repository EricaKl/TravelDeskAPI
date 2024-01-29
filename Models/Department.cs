using System.ComponentModel.DataAnnotations;

namespace TravelDeskAPI.Models
{
    public class Department
    {
        [Key]
        public int DeptId { get; set; }
        public string DepartmentName { get; set; }
        public int CreateBy { get; set; }
        public int? UpdateBy { get; set; } = null;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}

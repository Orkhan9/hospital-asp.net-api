using System.ComponentModel.DataAnnotations;
using Hospital.DAL.Entities;

namespace Hospital.BLL.DTO
{
    public class DoctorReturnDto:BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Profession { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Facebook { get; set; }
        public int DepartmentId { get; set; }

        public string Department { get; set; }
    }
}
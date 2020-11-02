using System.ComponentModel.DataAnnotations;
using Hospital.DAL.Entities;

namespace Hospital.BLL.DTO
{
    public class DepartmentUpdateDto:BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
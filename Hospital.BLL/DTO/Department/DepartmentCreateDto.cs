using System.ComponentModel.DataAnnotations;

namespace Hospital.BLL.DTO.Department
{
    public class DepartmentCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
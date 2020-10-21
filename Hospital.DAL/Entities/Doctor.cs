using System.ComponentModel.DataAnnotations;

namespace Hospital.DAL.Entities
{
    public class Doctor:BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Profession { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Facebook { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        
    }
}
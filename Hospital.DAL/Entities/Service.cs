using System.ComponentModel.DataAnnotations;

namespace Hospital.DAL.Entities
{
    public class Service:BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ShortDesc { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace Hospital.BLL.DTO.Service
{
    public class ServiceCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ShortDesc { get; set; }
    }
}
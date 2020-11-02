using System.ComponentModel.DataAnnotations;
using Hospital.DAL.Entities;
using Microsoft.AspNetCore.Http;

namespace Hospital.BLL.DTO
{
    public class DoctorUpdateDto:BaseEntity
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
        public string PhotoUrl { get; set; }
      
        public IFormFile Photo { get; set; }
    }
}
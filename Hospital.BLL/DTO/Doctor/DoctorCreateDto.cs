using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Hospital.DAL.Entities;
using Microsoft.AspNetCore.Http;

namespace Hospital.BLL.DTO.Doctor
{
    public class DoctorCreateDto
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
        [Required]
        public IFormFile Photo { get; set; }
    }
}
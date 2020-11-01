using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Hospital.DAL.Entities
{
    public class Doctor:BaseEntity
    {
        public string PhotoUrl { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Profession { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Facebook { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set;}
        public ICollection<Appointment> Appointments { get; set; }
        
    }
}
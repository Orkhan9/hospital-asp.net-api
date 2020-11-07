using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Hospital.DAL.Entities
{
    public class Doctor:BaseEntity
    {
        public string PhotoUrl { get; set; }
        public string Name { get; set; }
        public string Profession { get; set; }
        public string Description { get; set; }
        public string Facebook { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set;}
        public ICollection<Appointment> Appointments { get; set; }
        
    }
}
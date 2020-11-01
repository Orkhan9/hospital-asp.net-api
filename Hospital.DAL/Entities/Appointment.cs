using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace Hospital.DAL.Entities
{
    public class Appointment:BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required,DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Message { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
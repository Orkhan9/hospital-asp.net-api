using System;
using System.ComponentModel.DataAnnotations;
using Hospital.DAL.Entities;

namespace Hospital.BLL.DTO.Appointment
{
    public class AppointmentReturnDto:BaseEntity
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
        public string Doctor { get; set; }
    }
}
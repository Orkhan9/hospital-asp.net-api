using System.ComponentModel.DataAnnotations;
using Hospital.DAL.Entities;

namespace Hospital.BLL.DTO
{
    public class BioUpdateDto:BaseEntity
    {
        
        public string Logo { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Facebook { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
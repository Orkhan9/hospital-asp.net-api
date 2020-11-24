using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Hospital.DAL.Entities;
using Microsoft.AspNetCore.Http;

namespace Hospital.BLL.DTO.Bio
{
    public class BioUpdateDto:BaseEntity
    {
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Facebook { get; set; }
        [Required]
        public string Address { get; set; }
        [NotMapped]
        public IFormFile Logo { get; set; }
    }
}
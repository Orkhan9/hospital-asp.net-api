using System.ComponentModel.DataAnnotations;

namespace Hospital.DAL.Entities
{
    public class Bio:BaseEntity
    {
        [Required]
        public string Logo { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]

        public string Facebook { get; set; }
        [Required]
        public string Adress { get; set; }
    }
}
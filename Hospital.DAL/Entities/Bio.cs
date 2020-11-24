using System.ComponentModel.DataAnnotations;

namespace Hospital.DAL.Entities
{
    public class Bio:BaseEntity
    {
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Facebook { get; set; }
        public string Address { get; set; }
        public string LogoUrl { get; set; }
    }
}
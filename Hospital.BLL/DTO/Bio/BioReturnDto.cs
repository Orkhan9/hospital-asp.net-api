using Hospital.DAL.Entities;

namespace Hospital.BLL.DTO.Bio
{
    public class BioReturnDto:BaseEntity
    {
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Facebook { get; set; }
        public string Address { get; set; }
        public string LogoUrl { get; set; }
    }
}
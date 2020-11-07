using Hospital.DAL.Entities;

namespace Hospital.BLL.DTO
{
    public class BioReturnDto:BaseEntity
    {
        public string Logo { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Facebook { get; set; }
        public string Address { get; set; }
    }
}
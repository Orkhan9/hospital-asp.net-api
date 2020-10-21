using Hospital.DAL.Entities;

namespace Hospital.BLL.DTO
{
    public class DoctorDto:BaseEntity
    {
        public string Name { get; set; }
        public string Profession { get; set; }
        public string Description { get; set; }
        public string Facebook { get; set; }
        public string Department { get; set; }
    }
}
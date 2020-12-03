using Hospital.DAL.Entities;

namespace Hospital.BLL.DTO.Service
{
    public class ServiceReturnDto:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortDesc { get; set; }
        public string IconClass { get; set; }
    }
}
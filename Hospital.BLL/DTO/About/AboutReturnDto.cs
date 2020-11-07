using Hospital.DAL.Entities;

namespace Hospital.BLL.DTO
{
    public class AboutReturnDto:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
using Hospital.DAL.Entities;

namespace Hospital.BLL.DTO.About
{
    public class AboutReturnDto:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
    }
}
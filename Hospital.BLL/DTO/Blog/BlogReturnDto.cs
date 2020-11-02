using System;
using System.Collections.Generic;
using Hospital.DAL.Entities;

namespace Hospital.BLL.DTO
{
    public class BlogReturnDto:BaseEntity
    {
        public string Title { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public DateTime PublishTime { get; set; }
        public ICollection<string> Comments { get; set; }
    }
}
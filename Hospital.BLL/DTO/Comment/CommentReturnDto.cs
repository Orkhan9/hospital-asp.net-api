using System;
using Hospital.DAL.Entities;

namespace Hospital.BLL.DTO.Comment
{
    public class CommentReturnDto:BaseEntity
    {
        public string Context { get; set; }
        public DateTime PublishTime { get; set; }
        public string Blog { get; set; }
        public string User { get; set; }
    }
}
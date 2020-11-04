using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Hospital.DAL.Entities
{
    public class Comment:BaseEntity
    {
        public string Context { get; set; }
        public DateTime PublishTime { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }

        public Comment()
        {
            PublishTime=DateTime.Now;
        }
    }
}
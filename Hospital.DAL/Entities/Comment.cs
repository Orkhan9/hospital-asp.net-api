using System;
using System.ComponentModel.DataAnnotations;

namespace Hospital.DAL.Entities
{
    public class Comment:BaseEntity
    {
        [Required]
        public string Context { get; set; }
        public DateTime PublishTime { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
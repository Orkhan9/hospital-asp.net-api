using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hospital.DAL.Entities
{
    public class Blog:BaseEntity
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Topic { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string PhotoUrl { get; set; }
        public DateTime PublishTime { get; set; }
        public ICollection<Comment> Comments { get; set; }
        
    }
}
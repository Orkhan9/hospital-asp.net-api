using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Hospital.DAL.Entities;

namespace Hospital.BLL.DTO
{
    public class BlogCreateDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        
        public string Topic { get; set; }
        [Required]
        
        public string Description { get; set; }
        [Required]
        
        public string PhotoUrl { get; set; }
        [Required]
        public DateTime PublishTime { get; set; }

    }
}
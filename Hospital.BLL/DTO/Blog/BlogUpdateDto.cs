using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Hospital.DAL.Entities;
using Microsoft.AspNetCore.Http;

namespace Hospital.BLL.DTO.Blog
{
    public class BlogUpdateDto:BaseEntity
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Topic { get; set; }
        [Required]
        public string Description { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
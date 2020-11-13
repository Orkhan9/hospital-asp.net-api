using System;
using System.ComponentModel.DataAnnotations;
using Hospital.DAL.Entities;

namespace Hospital.BLL.DTO.Comment
{
    public class CommentCreateDto
    {
        [Required]
        public string Context { get; set; }
        public DateTime PublishTime { get; set; }
        [Required]
        public int BlogId { get; set; }
        public int UserId { get; set; }
    }
}
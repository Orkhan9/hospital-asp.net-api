using System;
using System.ComponentModel.DataAnnotations;

namespace Hospital.DAL.Entities
{
    public class Product:BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string PhotoUrl { get; set; }
    }
}
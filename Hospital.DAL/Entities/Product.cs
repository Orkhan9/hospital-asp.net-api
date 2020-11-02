using System;
using System.ComponentModel.DataAnnotations;

namespace Hospital.DAL.Entities
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string PhotoUrl { get; set; }
    }
}
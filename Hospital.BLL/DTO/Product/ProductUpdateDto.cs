using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Hospital.DAL.Entities;
using Microsoft.AspNetCore.Http;

namespace Hospital.BLL.DTO.Product
{
    public class ProductUpdateDto:BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        
        [Required]
        public string Description { get; set; }

        public int ProductBrandId { get; set; }
        public int ProductTypeId { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
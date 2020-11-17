using System.ComponentModel.DataAnnotations;
using Hospital.DAL.Entities;

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
        public string PictureUrl { get; set; }
    }
}
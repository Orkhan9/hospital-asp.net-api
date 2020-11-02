using System.ComponentModel.DataAnnotations;

namespace Hospital.BLL.DTO.Product
{
    public class ProductCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string PhotoUrl { get; set; }
    }
}
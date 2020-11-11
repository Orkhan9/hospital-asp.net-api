using Hospital.DAL.Entities;

namespace Hospital.BLL.DTO.Product
{
    public class ProductReturnDto:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }
        public string ProductType { get; set; }
        public string ProductBrand { get; set; }
    }
}
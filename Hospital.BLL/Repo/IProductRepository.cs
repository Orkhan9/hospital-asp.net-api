using System.Collections.Generic;
using System.Threading.Tasks;
using Hospital.BLL.Helpers;
using Hospital.DAL.Entities;

namespace Hospital.DAL
{
    public interface IProductRepository
    {
        Task<PagedList<Product>> GetProductAsync(ProductParams productParams);
        Task<Product> GetProductByIdAsync(int id);
        Task<Product> CreateProductAsync(Product product);
        Task<Product> UpdateProductAsync(Product product,string webRoot);
        Task<Product> DeleteProductAsync(int id,string webRoot);
    }
}
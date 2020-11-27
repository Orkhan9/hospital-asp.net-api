using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Hospital.BLL.Helpers;
using Hospital.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hospital.DAL
{
    public class ProductRepository:IProductRepository
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<PagedList<Product>> GetProductAsync(ProductParams productParams)
        {
            var products =  _context.Products.Include(x => x.ProductType)
                .Include(x => x.ProductBrand);
            return await PagedList<Product>.CreateAsync(products,productParams.PageNumber,productParams.PageSize);
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var product = await _context.Products.Include(x=>x.ProductType)
                .Include(x=>x.ProductBrand).FirstOrDefaultAsync(x => x.Id == id);
            return product;
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateProductAsync( Product product,string webRoot)
        {
            var dbProduct =await _context.Products.FirstOrDefaultAsync(x => x.Id == product.Id);
            if (dbProduct == null)
            {
                return dbProduct;
            }
            
            string folderName = Path.Combine("images", "shop");
            if (product.Photo!=null)
            {
                ImageExtension.DeleteImage(webRoot,folderName,dbProduct.PictureUrl);
                string fileName = await product.Photo.SaveImg(webRoot, folderName);
                dbProduct.PictureUrl = fileName;
            }
            dbProduct.Name = product.Name;
            dbProduct.Price = product.Price;
            dbProduct.Description = product.Description;
            dbProduct.ProductBrandId = product.ProductBrandId;
            dbProduct.ProductTypeId = product.ProductTypeId;
            await _context.SaveChangesAsync();
            return dbProduct;
        }


        public async Task<Product> DeleteProductAsync(int id,string webRoot)
        {
            var dbProduct = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (dbProduct == null)
            {
                return dbProduct;
            }
            
            string folderName = Path.Combine("images", "shop");
            
            _context.Products.Remove(dbProduct);
            ImageExtension.DeleteImage(webRoot,folderName,dbProduct.PictureUrl);
            await _context.SaveChangesAsync();
            
            return dbProduct;
        }
    }
}
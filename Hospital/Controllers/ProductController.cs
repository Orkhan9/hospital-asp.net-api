using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hospital.BLL.DTO.Product;
using Hospital.DAL;
using Hospital.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private string productImageUrl = "assets/images/shop/";
        private readonly DataContext _context;
        private IMapper _mapper;
        public ProductController(DataContext context,IMapper mapper)
        {
            _context=context;
            _mapper = mapper;
        }
        
        
        /// <summary>
        /// Get All Products
        /// </summary>
        /// <returns></returns>
        // GET: api/<ProductController>
        [HttpGet]
        public ActionResult<IEnumerable<ProductReturnDto>> Get()
        {
            var products = _context.Products
                .Include(t => t.ProductType)
                .Include(b=>b.ProductBrand).ToList();
            var mapperProducts = _mapper.Map<IEnumerable<ProductReturnDto>>(products);
            return Ok(mapperProducts);
        }
        
        /// <summary>
        /// Get Product from Id
        /// </summary>
        /// <param name="id">for product</param>
        /// <returns></returns>
        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ActionResult<ProductReturnDto> Get(int id)
        {
           var product = _context.Products
               .Include(t=>t.ProductType)
               .Include(b=>b.ProductBrand).FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            var mapperProduct = _mapper.Map<ProductReturnDto>(product);
            
            return Ok(mapperProduct);
        }
        
        /// <summary>
        /// Create new Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        // POST api/<ProductController>
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ProductCreateDto productCreateDto)
        {
            Product product = new Product
            {
                Name = productCreateDto.Name,
                Price = productCreateDto.Price,
                // PhotoUrl = productCreateDto.PhotoUrl
            };
            // product.PhotoUrl = productImageUrl + productCreateDto.PhotoUrl;
            await _context.AddAsync(product);
            await _context.SaveChangesAsync();
            return Ok(product);
        }
        
        /// <summary>
        /// Update Product
        /// </summary>
        /// <param name="id"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> Update(int id, [FromBody] ProductUpdateDto productUpdateDto)
        {
            if (id != productUpdateDto.Id) return BadRequest();
            Product dbproduct = _context.Products.FirstOrDefault(p => p.Id == id);
            if (dbproduct == null) return NotFound();

            dbproduct.Name = productUpdateDto.Name;
            dbproduct.Price = productUpdateDto.Price;
            // dbproduct.PhotoUrl = productImageUrl+productUpdateDto.PhotoUrl;
           
            await _context.SaveChangesAsync();
            return Ok(dbproduct);
        }
        
        /// <summary>
        /// Delete Product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Product dbproduct = _context.Products.FirstOrDefault(p => p.Id == id);
            if (dbproduct == null) return NotFound();
            _context.Products.Remove(dbproduct);
            await _context.SaveChangesAsync();
            return Ok();
        }
        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.DAL;
using Hospital.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private string productImageUrl = "assets/images/shop/";
        private readonly DataContext _context;
        public ProductController(DataContext context)
        {
            _context=context;
        }
        
        
        /// <summary>
        /// Get All Products
        /// </summary>
        /// <returns></returns>
        // GET: api/<ProductController>
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return Ok(_context.Products.ToList());
        }
        
        /// <summary>
        /// Get Product from Id
        /// </summary>
        /// <param name="id">for product</param>
        /// <returns></returns>
        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ActionResult<Blog> Get(int id)
        {
            Product product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            
            return Ok(product);
        }
        
        /// <summary>
        /// Create new Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        // POST api/<ProductController>
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Product product)
        {
            if (!ModelState.IsValid) return BadRequest();
            product.PhotoUrl = productImageUrl + product.PhotoUrl;
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
        public async Task<ActionResult<Product>> Update(int id, [FromBody] Product product)
        {
            if (id != product.Id) return BadRequest();
            Product dbproduct = _context.Products.FirstOrDefault(p => p.Id == id);
            if (dbproduct == null) return NotFound();

            dbproduct.Name = product.Name;
            dbproduct.Price = product.Price;
            dbproduct.PhotoUrl = productImageUrl+product.PhotoUrl;
           
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
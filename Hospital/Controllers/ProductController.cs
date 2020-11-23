using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hospital.BLL.DTO.Product;
using Hospital.BLL.Helpers;
using Hospital.DAL;
using Hospital.DAL.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        public ProductController(IProductRepository productRepository,
            IMapper mapper,
            IWebHostEnvironment env)
        {
            _productRepository=productRepository;
            _mapper = mapper;
            _env = env;
        }
        
        
        /// <summary>
        /// Get All Products
        /// </summary>
        /// <returns></returns>
        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductReturnDto>>> Get([FromQuery] ProductParams productParams)
        {
            var dbproducts = await _productRepository.GetProductAsync(productParams);
            var mapperProducts = _mapper.Map<IEnumerable<ProductReturnDto>>(dbproducts);
            Response.AddPagination(dbproducts.CurrentPage,dbproducts.PageSize
                ,dbproducts.TotalCount,dbproducts.TotalPage);
            return Ok(mapperProducts);
        }
        
        /// <summary>
        /// Get Product from Id
        /// </summary>
        /// <param name="id">for product</param>
        /// <returns></returns>
        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductReturnDto>> Get(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
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
        public async Task<ActionResult> Create([FromForm] ProductCreateDto productCreateDto)
        {
            var product = _mapper.Map<Product>(productCreateDto);
            
            string folderName = Path.Combine("images", "shop");
            string fileName = await productCreateDto.Photo.SaveImg(_env.WebRootPath, folderName);
            product.PictureUrl = fileName;
            await _productRepository.CreateProductAsync(product);
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
        public async Task<ActionResult<Product>> Update(int id, [FromForm] ProductUpdateDto productUpdateDto)
        {
            if (id != productUpdateDto.Id) return BadRequest();
            var mapperproduct = _mapper.Map<Product>(productUpdateDto);
            Product product=await _productRepository.UpdateProductAsync(mapperproduct);
            if (product == null) return BadRequest();
           
            return Ok(product);
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
            Product product = await _productRepository.DeleteProductAsync(id);
            if (product == null) return NotFound();
            return Ok();
        }
        
    }
}
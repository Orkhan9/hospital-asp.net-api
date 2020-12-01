using System.Collections.Generic;
using System.Linq;
using Hospital.DAL;
using Hospital.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductBrandController : ControllerBase
    {
        private readonly DataContext _context;
        public ProductBrandController(DataContext context)
        {
            _context=context;
        }
        /// <summary>
        /// Get All ProductBrands
        /// </summary>
        /// <returns></returns>
        // GET: api/<ProductBrandController>
        [HttpGet]
        public ActionResult<IEnumerable<ProductBrand>> Get()
        {
            var productBrands = _context.ProductBrands.ToList();
            return Ok(productBrands);
        }
    }
}
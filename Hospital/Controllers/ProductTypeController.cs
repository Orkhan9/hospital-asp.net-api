using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Hospital.BLL.DTO.Comment;
using Hospital.DAL;
using Hospital.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        private readonly DataContext _context;
        public ProductTypeController(DataContext context)
        {
            _context=context;
        }
        /// <summary>
        /// Get All ProductTypes
        /// </summary>
        /// <returns></returns>
        // GET: api/<ProductTypeController>
        [HttpGet]
        public ActionResult<IEnumerable<ProductType>> Get()
        {
            var productTypes = _context.ProductTypes.ToList();
            return Ok(productTypes);
        }
    }
}
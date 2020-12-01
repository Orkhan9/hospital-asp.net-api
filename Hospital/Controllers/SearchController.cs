using System.Collections.Generic;
using System.Linq;
using Hospital.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly DataContext _context;
        public SearchController(DataContext context)
        {
            _context=context;
        }
        
        /// <summary>
        /// Get All Search
        /// </summary>
        /// <returns></returns>
        // GET: api/<SearchController>
        [HttpGet]
        public ActionResult<IEnumerable<object>> Get(string name,string path)
        {
            IEnumerable<object> searchList=new List<object>();
            
            if (name != null && (path == "home" || path == "" || path == "doctor"))
            {
                searchList=_context.Doctors.Where(x => x.Name.ToLower()
                    .Contains(name.ToLower())).ToList();
            }
            
            if (name != null && path == "blog")
            {
                searchList=_context.Blogs.Where(x => x.Title.ToLower()
                    .Contains(name.ToLower())).ToList();
            }
            
            if (name != null && path == "department")
            {
                searchList=_context.Departments.Where(x => x.Name.ToLower()
                    .Contains(name.ToLower())).ToList();
            }
            
            if (name != null && path == "shop")
            {
                searchList=_context.Products.Where(x => x.Name.ToLower()
                    .Contains(name.ToLower())).ToList();
            }
            
            return Ok(searchList);
        } 
    }
}
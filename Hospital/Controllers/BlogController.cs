using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Hospital.DAL;
using Hospital.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly DataContext _context;
        public BlogController(DataContext context)
        {
            _context=context;
        }
        
        
        /// <summary>
        /// Get All Blogs
        /// </summary>
        /// <returns></returns>
        // GET: api/<BlogController>
        [HttpGet]
        public ActionResult<IEnumerable<Blog>> Get()
        {
            return Ok(_context.Blogs.ToList());
        }
        
        /// <summary>
        /// Get Blog from Id
        /// </summary>
        /// <param name="id">for blog</param>
        /// <returns></returns>
        // GET api/<BlogController>/5
        [HttpGet("{id}")]
        public ActionResult<Blog> Get(int id)
        {
            Blog blog = _context.Blogs.FirstOrDefault(p => p.Id == id);
            if (blog == null) return NotFound();
            
            return Ok(blog);
        }
        
        /// <summary>
        /// Create new Blog
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        // POST api/<BlogController>
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Blog blog)
        {
            if (!ModelState.IsValid) return BadRequest();
            blog.PublishTime = DateTime.Now;
            await _context.AddAsync(blog);
            await _context.SaveChangesAsync();
            return Ok(blog);
        }
        
        /// <summary>
        /// Update Blog
        /// </summary>
        /// <param name="id"></param>
        /// <param name="blog"></param>
        /// <returns></returns>
        // PUT api/<BlogController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Blog>> Update(int id, [FromBody] Blog blog)
        {
            if (id != blog.Id) return BadRequest();
            Blog dbblog = _context.Blogs.FirstOrDefault(p => p.Id == id);
            if (dbblog == null) return NotFound();

            dbblog.Title = blog.Title;
            dbblog.Topic = blog.Topic;
            dbblog.Description = blog.Description;
            dbblog.PhotoUrl = blog.PhotoUrl;
            dbblog.PublishTime = blog.PublishTime;
            dbblog.Comments = blog.Comments;
            await _context.SaveChangesAsync();
            return Ok(dbblog);
        }
        
        /// <summary>
        /// Delete Blog
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE api/<BlogController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Blog dbblog = _context.Blogs.FirstOrDefault(p => p.Id == id);
            if (dbblog == null) return NotFound();
            _context.Blogs.Remove(dbblog);
            await _context.SaveChangesAsync();
            return Ok();
        }
        
    }
}
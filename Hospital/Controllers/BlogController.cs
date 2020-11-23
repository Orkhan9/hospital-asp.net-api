using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using Hospital.BLL.DTO;
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
    public class BlogController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        public BlogController(DataContext context,IMapper mapper,
            IWebHostEnvironment env)
        {
            _context=context;
            _mapper = mapper;
            _env = env;
        }
        
        
        /// <summary>
        /// Get All Blogs
        /// </summary>
        /// <returns></returns>
        // GET: api/<BlogController>
        [HttpGet]
        public ActionResult<IEnumerable<Blog>> Get()
        {
            var blogs= _context.Blogs.Include(x => x.Comments).ToList();
            var mapperblogs = _mapper.Map<IEnumerable<Blog>,IEnumerable<BlogReturnDto>>(blogs);
            return Ok(mapperblogs);
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
            Blog blog = _context.Blogs.Include(x=>x.Comments).FirstOrDefault(p => p.Id == id);
            if (blog == null) return NotFound();
            var mapperblog = _mapper.Map<Blog,BlogReturnDto>(blog);
            
            return Ok(mapperblog);
        }
        
        /// <summary>
        /// Create new Blog
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        // POST api/<BlogController>
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] BlogCreateDto blogCreateDto)
        {
            
            Blog blog=new Blog();
            blog.Title = blogCreateDto.Title;
            blog.Topic = blogCreateDto.Topic;
            blog.Description = blogCreateDto.Description;
            
            string folderName = Path.Combine("images", "blog");
            string fileName = await blogCreateDto.Photo.SaveImg(_env.WebRootPath, folderName);
            blog.PhotoUrl = fileName;
            
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
        public async Task<ActionResult<Blog>> Update(int id, [FromBody] BlogUpdateDto blogUpdateDto)
        {
            
            if (id != blogUpdateDto.Id) return BadRequest();
            Blog dbblog = _context.Blogs.FirstOrDefault(p => p.Id == id);
            if (dbblog == null) return NotFound();

            dbblog.Title = blogUpdateDto.Title;
            dbblog.Topic = blogUpdateDto.Topic;
            dbblog.Description = blogUpdateDto.Description;
            dbblog.PhotoUrl = blogUpdateDto.PhotoUrl;
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
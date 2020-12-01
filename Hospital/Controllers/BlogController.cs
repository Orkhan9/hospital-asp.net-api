using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hospital.BLL.DTO.Blog;
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
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        public BlogController(IMapper mapper,
            IWebHostEnvironment env,
            IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
            _env = env;
        }
        
        
        /// <summary>
        /// Get All Blogs
        /// </summary>
        /// <returns></returns>
        // GET: api/<BlogController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var blogs = await _blogRepository.GetBlogsAsync();
            var mapperBlogs = _mapper.Map<IEnumerable<BlogReturnDto>>(blogs);
            return Ok(mapperBlogs);
        }
        
        /// <summary>
        /// Get Blog from Id
        /// </summary>
        /// <param name="id">for blog</param>
        /// <returns></returns>
        // GET api/<BlogController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var blog = await _blogRepository.GetBlogByIdAsync(id);
            if (blog == null) return NotFound();
            var mapperBlog = _mapper.Map<BlogReturnDto>(blog);
            
            return Ok(mapperBlog);
        }
        
        /// <summary>
        /// Create new Blog
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        // POST api/<BlogController>
        [HttpPost]
        public async Task<ActionResult> Create([FromForm] BlogCreateDto blogCreateDto)
        {
            var mapperBlog = _mapper.Map<Blog>(blogCreateDto);
            
            string folderName = Path.Combine("images", "blog");
            string fileName = await blogCreateDto.Photo.SaveImg(_env.WebRootPath, folderName);
            mapperBlog.PhotoUrl = fileName;
            await _blogRepository.CreateBlogAsync(mapperBlog);
            return Ok(mapperBlog);
        }
        
        /// <summary>
        /// Update Blog
        /// </summary>
        /// <param name="id"></param>
        /// <param name="blog"></param>
        /// <returns></returns>
        // PUT api/<BlogController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Blog>> Update(int id, [FromForm] BlogUpdateDto blogUpdateDto)
        {
            if (id != blogUpdateDto.Id) return BadRequest();
            var mapperBlog = _mapper.Map<Blog>(blogUpdateDto);
            var blog= await _blogRepository.UpdateBlogAsync(mapperBlog,_env.WebRootPath);
            if (blog == null) return BadRequest();
           
            return Ok(blog);
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
            Blog blog = await _blogRepository.DeleteBlogAsync(id,_env.WebRootPath);
            if (blog == null) return NotFound();
            return Ok();
        }
    }
}
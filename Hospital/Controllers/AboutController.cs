using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hospital.BLL.DTO;
using Hospital.BLL.DTO.About;
using Hospital.BLL.Helpers;
using Hospital.DAL;
using Hospital.DAL.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        public AboutController(DataContext context,
                               IMapper mapper,
                               IWebHostEnvironment env)
        {
            _context=context;
            _mapper = mapper;
            _env = env;
        }
        
        /// <summary>
        /// Get About
        /// </summary>
        /// <returns></returns>
        //GET: api/<AboutController>
        [HttpGet]
        public ActionResult<AboutReturnDto> Get()
        {
            About about = _context.Abouts.FirstOrDefault();
            var mapperAbout = _mapper.Map<About,AboutReturnDto>(about);
            return Ok(mapperAbout);
        }
        
        /// <summary>
        /// Update About
        /// </summary>
        /// <param name="id"></param>
        /// <param name="about"></param>
        /// <returns></returns>
        // PUT api/<AboutController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<About>> Update(int id, [FromForm] AboutUpdateDto aboutUpdateDto)
        {
            if (id != aboutUpdateDto.Id) return BadRequest();
            About dbAbout = _context.Abouts.FirstOrDefault(p => p.Id == id);
            if (dbAbout == null) return NotFound();
            dbAbout.Title = aboutUpdateDto.Title;
            dbAbout.Description = aboutUpdateDto.Description;
            
            string folderName = Path.Combine("images", "about");
            if (aboutUpdateDto.Photo!=null)
            {
                ImageExtension.DeleteImage(_env.WebRootPath,folderName,dbAbout.PhotoUrl);
                string fileName = await aboutUpdateDto.Photo.SaveImg(_env.WebRootPath, folderName);
                dbAbout.PhotoUrl = fileName;
            }
            await _context.SaveChangesAsync();
             return Ok();
        }
    }
}
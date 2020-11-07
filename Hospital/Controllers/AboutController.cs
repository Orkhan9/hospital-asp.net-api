using System.Linq;
using System.Threading.Tasks;
using Hospital.BLL.DTO;
using Hospital.DAL;
using Hospital.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly DataContext _context;
        public AboutController(DataContext context)
        {
            _context=context;
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
            return Ok(about);
        }
        
        /// <summary>
        /// Update About
        /// </summary>
        /// <param name="id"></param>
        /// <param name="about"></param>
        /// <returns></returns>
        // PUT api/<AboutController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<About>> Update(int id, [FromBody] AboutUpdateDto aboutUpdateDto)
        {
            if (id != aboutUpdateDto.Id) return BadRequest();
            About dbAbout = _context.Abouts.FirstOrDefault(p => p.Id == id);
            if (dbAbout == null) return NotFound();
            
            dbAbout.Title = aboutUpdateDto.Title;
            dbAbout.Description = aboutUpdateDto.Description;
            await _context.SaveChangesAsync();
             return Ok();
        }
        
        
        
    }
}
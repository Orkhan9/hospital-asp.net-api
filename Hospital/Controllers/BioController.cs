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
    public class BioController : ControllerBase
    {
        private readonly DataContext _context;
        public BioController(DataContext context)
        {
            _context=context;
        }
        
        /// <summary>
        /// Get Bio
        /// </summary>
        /// <returns></returns>
        //GET: api/<BioController>
        [HttpGet]
        public ActionResult<BioReturnDto> Get()
        {
            Bio bio = _context.Bios.FirstOrDefault();
            return Ok(bio);
        }
        
        /// <summary>
        /// Update Bio
        /// </summary>
        /// <param name="id"></param>
        /// <param name="bio"></param>
        /// <returns></returns>
        // PUT api/<BioController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Bio>> Update(int id, [FromBody] BioUpdateDto bioUpdateDto)
        {
            if (id != bioUpdateDto.Id) return BadRequest();
            Bio dbbio = _context.Bios.FirstOrDefault(p => p.Id == id);
            if (dbbio == null) return NotFound();

            dbbio.Logo = bioUpdateDto.Logo;
            dbbio.Phone = bioUpdateDto.Phone;
            dbbio.Email = bioUpdateDto.Email;
            dbbio.Facebook = bioUpdateDto.Facebook;
            dbbio.Address = bioUpdateDto.Address;
            await _context.SaveChangesAsync();
            return Ok(dbbio);
        }
        
        
        
    }
}
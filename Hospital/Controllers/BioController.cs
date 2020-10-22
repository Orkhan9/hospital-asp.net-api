using System.Linq;
using System.Threading.Tasks;
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
        /// Update Bio
        /// </summary>
        /// <param name="id"></param>
        /// <param name="bio"></param>
        /// <returns></returns>
        // PUT api/<BioController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Department>> Update(int id, [FromBody] Bio bio)
        {
            if (id != bio.Id) return BadRequest();
            Bio dbbio = _context.Bios.FirstOrDefault(p => p.Id == id);
            if (dbbio == null) return NotFound();

            dbbio.Logo = bio.Logo;
            dbbio.Phone = bio.Phone;
            dbbio.Email = bio.Email;
            dbbio.Facebook = bio.Facebook;
            dbbio.Adress = bio.Adress;
            await _context.SaveChangesAsync();
            return Ok(dbbio);
        }
        
        
        
    }
}
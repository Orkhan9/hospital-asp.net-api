using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hospital.BLL.DTO;
using Hospital.BLL.DTO.Bio;
using Hospital.BLL.Helpers;
using Hospital.DAL;
using Hospital.DAL.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BioController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        public BioController(DataContext context,
                            IMapper mapper,
                            IWebHostEnvironment env)
        {
            _context=context;
            _mapper = mapper;
            _env = env;
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
            var mapperBio = _mapper.Map<Bio,BioReturnDto>(bio);
            return Ok(mapperBio);
        }
        
        /// <summary>
        /// Update Bio
        /// </summary>
        /// <param name="id"></param>
        /// <param name="bio"></param>
        /// <returns></returns>
        // PUT api/<BioController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Bio>> Update(int id, [FromForm] BioUpdateDto bioUpdateDto)
        {
            if (id != bioUpdateDto.Id) return BadRequest();
            Bio dbBio = _context.Bios.FirstOrDefault(p => p.Id == id);
            if (dbBio == null) return NotFound();
            dbBio.Phone = bioUpdateDto.Phone;
            dbBio.Email = bioUpdateDto.Email;
            dbBio.Facebook = bioUpdateDto.Facebook;
            dbBio.Address = bioUpdateDto.Address;
            
            string folderName = Path.Combine("images", "logo");
            if (bioUpdateDto.Logo!=null)
            {
                ImageExtension.DeleteImage(_env.WebRootPath,folderName,dbBio.LogoUrl);
                string fileName = await bioUpdateDto.Logo.SaveImg(_env.WebRootPath, folderName);
                dbBio.LogoUrl = fileName;
            }
            await _context.SaveChangesAsync();
            return Ok(dbBio);
        }  
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hospital.BLL.DTO;
using Hospital.DAL;
using Hospital.DAL.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private IWebHostEnvironment _env;
        public DoctorController(DataContext context,IMapper mapper,IWebHostEnvironment env)
        {
            _context=context;
            _mapper = mapper;
            _env = env;
        }
        /// <summary>
        /// Get All Doctors
        /// </summary>
        /// <returns></returns>
        // GET: api/<DoctorController>
        [HttpGet]
        public ActionResult<IEnumerable<DoctorDto>> Get()
        {
            List<Doctor> doctors = _context.Doctors.Include(d => d.Department).ToList();
            var mapperdoctors = _mapper.Map<IEnumerable<Doctor>,IEnumerable<DoctorDto>>(doctors);
            return Ok(mapperdoctors);
        }
        
        /// <summary>
        /// Get Doctors by Department
        /// </summary>
        /// <returns></returns>
        // GET: api/<DoctorController>
        [HttpGet("GetDoctorByDepartment/{id}")]
        public ActionResult<IEnumerable<Doctor>> GetDoctorByDepartment(int id)
        {
            List<Doctor> doctors = _context.Doctors.Where(x=>x.DepartmentId==id).ToList();
            
            return Ok(doctors);
        }

        /// <summary>
        /// Get Doctor from Id
        /// </summary>
        /// <param name="id">for doctor</param>
        /// <returns></returns>
        // GET api/<DoctorController>/5
        [HttpGet("{id}")]
        public ActionResult<DoctorDto> Get(int id)
        {
            Doctor doctor = _context.Doctors.Include(d=>d.Department).FirstOrDefault(p => p.Id == id);
            if (doctor == null) return NotFound();
            var mapperdoctor = _mapper.Map<Doctor, DoctorDto>(doctor);
            
            return Ok(mapperdoctor);
        }

        /// <summary>
        /// Create new Doctor
        /// </summary>
        /// <param name="doctor"></param>
        /// <returns></returns>
        // POST api/<DoctorController>
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] DoctorCreateDto doctorCreateDto)
        {
            Doctor newdoctor = new Doctor
            {
                Name = doctorCreateDto.Name,
                Description = doctorCreateDto.Description,
                Facebook = doctorCreateDto.Facebook,
                DepartmentId = doctorCreateDto.DepartmentId,
                Profession = doctorCreateDto.Profession
            };
            string path = Guid.NewGuid()+"/wwwroot/images/" + doctorCreateDto.Photo.FileName;
            FileStream stream=new FileStream(path,FileMode.Create);
            await doctorCreateDto.Photo.CopyToAsync(stream);
            newdoctor.PhotoUrl = doctorCreateDto.Photo.FileName;
            // newdoctor.PhotoUrl=doctorCreateDto.Photo
            // string path = doctorCreateDto.PhotoUrl;
            await _context.AddAsync(newdoctor);
            await _context.SaveChangesAsync();
            return Ok(newdoctor);
        }
        
        /// <summary>
        /// Update Doctor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="doctor"></param>
        /// <returns></returns>
        // PUT api/<DoctorController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Doctor>> Update(int id, [FromBody] DoctorUpdateDto doctorUpdateDto)
        {
            if (id != doctorUpdateDto.Id) return BadRequest();
            Doctor dbDoctor = _context.Doctors.Include(d=>d.Department).FirstOrDefault(p => p.Id == id);
            if (dbDoctor == null) return NotFound();

            dbDoctor.Name = doctorUpdateDto.Name;
            dbDoctor.Description = doctorUpdateDto.Description;
            dbDoctor.Facebook = doctorUpdateDto.Facebook;
            dbDoctor.Profession = doctorUpdateDto.Profession;
            await _context.SaveChangesAsync();
            return Ok(dbDoctor);
        }

        /// <summary>
        /// Delete Doctor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE api/<DoctorController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Doctor dbDoctor = _context.Doctors.FirstOrDefault(p => p.Id == id);
            if (dbDoctor == null) return NotFound();
            _context.Doctors.Remove(dbDoctor);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using AutoMapper;
using Hospital.BLL.DTO;
using Hospital.BLL.Helpers;
using Hospital.DAL;
using Hospital.DAL.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
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
        public ActionResult<IEnumerable<DoctorReturnDto>> Get()
        {
            List<Doctor> doctors = _context.Doctors.Include(d => d.Department).ToList();
            var mapperdoctors = _mapper.Map<IEnumerable<Doctor>,IEnumerable<DoctorReturnDto>>(doctors);
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
        public ActionResult<DoctorReturnDto> Get(int id)
        {
            Doctor doctor = _context.Doctors.Include(d=>d.Department).FirstOrDefault(p => p.Id == id);
            if (doctor == null) return NotFound();
            var mapperdoctor = _mapper.Map<Doctor, DoctorReturnDto>(doctor);
            
            return Ok(mapperdoctor);
        }

        /// <summary>
        /// Create new Doctor
        /// </summary>
        /// <param name="doctor"></param>
        /// <returns></returns>
        // POST api/<DoctorController>
        [HttpPost]
        public async Task<ActionResult> Create([FromForm] DoctorCreateDto doctorCreateDto)
        {
            Doctor newdoctor = new Doctor
            {
                Name = doctorCreateDto.Name,
                Description = doctorCreateDto.Description,
                Facebook = doctorCreateDto.Facebook,
                DepartmentId = doctorCreateDto.DepartmentId,
                Profession = doctorCreateDto.Profession
            };

            string folderName = Path.Combine("images", "doctors");
            string fileName = await doctorCreateDto.Photo.SaveImg(_env.WebRootPath, folderName);
            newdoctor.PhotoUrl = fileName;
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
        public async Task<ActionResult<Doctor>> Update(int id, [FromForm] DoctorUpdateDto doctorUpdateDto)
        {
            if (id != doctorUpdateDto.Id) return BadRequest();
            Doctor dbDoctor = _context.Doctors.Include(d=>d.Department).FirstOrDefault(p => p.Id == id);
            if (dbDoctor == null) return NotFound();

            dbDoctor.Name = doctorUpdateDto.Name;
            dbDoctor.Description = doctorUpdateDto.Description;
            dbDoctor.Facebook = doctorUpdateDto.Facebook;
            dbDoctor.Profession = doctorUpdateDto.Profession;
            dbDoctor.DepartmentId = doctorUpdateDto.DepartmentId;
            
            string folderName = Path.Combine("images", "doctors");
            if (doctorUpdateDto.Photo!=null)
            {
                ImageExtension.DeleteImage(_env.WebRootPath,folderName,dbDoctor.PhotoUrl);
                string fileName = await doctorUpdateDto.Photo.SaveImg(_env.WebRootPath, folderName);
                dbDoctor.PhotoUrl = fileName;
            }
            
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
            
            string folderName = Path.Combine("images", "doctors");
            
            _context.Doctors.Remove(dbDoctor);
            ImageExtension.DeleteImage(_env.WebRootPath,folderName,dbDoctor.PhotoUrl);
            await _context.SaveChangesAsync();
            return Ok();
        }
        
        
    }
}
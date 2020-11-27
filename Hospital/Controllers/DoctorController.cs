using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Hospital.BLL.DTO.Doctor;
using Hospital.BLL.Helpers;
using Hospital.DAL;
using Hospital.DAL.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IWebHostEnvironment _env;
        private readonly IDoctorRepository _doctorRepository;
        public DoctorController(IMapper mapper,
                IWebHostEnvironment env,
                IDoctorRepository doctorRepository)
        {
            _mapper = mapper;
            _env = env;
            _doctorRepository = doctorRepository;
        }
        
        /// <summary>
        /// Get All Doctors
        /// </summary>
        /// <returns></returns>
        // GET: api/<DoctorController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var doctors = await _doctorRepository.GetDoctorsAsync();
            var mapperDoctors = _mapper.Map<IEnumerable<DoctorReturnDto>>(doctors);
            return Ok(mapperDoctors);
        }
        
        /// <summary>
        /// Get Doctors by Department
        /// </summary>
        /// <returns></returns>
        // GET: api/<DoctorController>
        [HttpGet("GetDoctorByDepartment/{id}")]
        public async Task<IActionResult> GetDoctorByDepartment(int id)
        {
            var doctors = await _doctorRepository.GetDoctorByDepartmentIdAsync(id);
            var mapperDoctors = _mapper.Map<IEnumerable<DoctorReturnDto>>(doctors);
            return Ok(mapperDoctors);
        }

        /// <summary>
        /// Get Doctor from Id
        /// </summary>
        /// <param name="id">for doctor</param>
        /// <returns></returns>
        // GET api/<DoctorController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var doctor = await _doctorRepository.GetDoctorByIdAsync(id);
            if (doctor == null) return NotFound();
            var mapperDoctor = _mapper.Map<DoctorReturnDto>(doctor);
            
            return Ok(mapperDoctor);
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
            var mapperDoctor = _mapper.Map<Doctor>(doctorCreateDto);
            
            string folderName = Path.Combine("images", "doctors");
            string fileName = await doctorCreateDto.Photo.SaveImg(_env.WebRootPath, folderName);
            mapperDoctor.PhotoUrl = fileName;
            await _doctorRepository.CreateDoctorAsync(mapperDoctor);
            return Ok(mapperDoctor);
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
            var mapperDoctor = _mapper.Map<Doctor>(doctorUpdateDto);
            var doctor= await _doctorRepository.UpdateDoctorAsync(mapperDoctor,_env.WebRootPath);
            if (doctor == null) return BadRequest();
           
            return Ok(doctor);
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
            Doctor doctor = await _doctorRepository.DeleteDoctorAsync(id,_env.WebRootPath);
            if (doctor == null) return NotFound();
            return Ok();
        }
        
        
    }
}
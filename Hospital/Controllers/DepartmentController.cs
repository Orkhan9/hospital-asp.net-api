using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hospital.BLL.DTO.Department;
using Hospital.DAL;
using Hospital.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public DepartmentController(DataContext context,IMapper mapper)
        {
            _context=context;
            _mapper = mapper;
        }
        
        
        /// <summary>
        /// Get All Departments
        /// </summary>
        /// <returns></returns>
        // GET: api/<DepartmentController>
        [HttpGet]
        public ActionResult<IEnumerable<DepartmentReturnDto>> Get()
        {
            var departments = _context.Departments.Include(x => x.Doctors).ToList();
            var mapperDepartments = _mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentReturnDto>>(departments);
            return Ok(mapperDepartments);
        }
        
        /// <summary>
        /// Get Department from Id
        /// </summary>
        /// <param name="id">for department</param>
        /// <returns></returns>
        // GET api/<DepartmentController>/5
        [HttpGet("{id}")]
        public ActionResult<DepartmentReturnDto> Get(int id)
        {
            Department department = _context.Departments.Include(x=>x.Doctors).FirstOrDefault(p => p.Id == id);
            if (department == null) return NotFound();
            var mapperDepartment = _mapper.Map<Department, DepartmentReturnDto>(department);
            
            return Ok(mapperDepartment);
        }
        
        /// <summary>
        /// Create new Department
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        // POST api/<DepartmentController>
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] DepartmentCreateDto departmentCreateDto)
        {
            Department department = new Department
            {
                Name = departmentCreateDto.Name,
                Description = departmentCreateDto.Description
            };
            await _context.AddAsync(department);
            await _context.SaveChangesAsync();
            return Ok(department);
        }
        
        /// <summary>
        /// Update Department
        /// </summary>
        /// <param name="id"></param>
        /// <param name="department"></param>
        /// <returns></returns>
        // PUT api/<DepartmentController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Department>> Update(int id, [FromBody] DepartmentUpdateDto departmentUpdateDto)
        {
            if (id != departmentUpdateDto.Id) return BadRequest();
            Department dbDepartment = _context.Departments.FirstOrDefault(p => p.Id == id);
            if (dbDepartment == null) return NotFound();

            dbDepartment.Name = departmentUpdateDto.Name;
            dbDepartment.Description = departmentUpdateDto.Description;
            await _context.SaveChangesAsync();
            return Ok(dbDepartment);
        }
        
        /// <summary>
        /// Delete Department
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE api/<DepartmentController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Department dbDepartment = _context.Departments.FirstOrDefault(p => p.Id == id);
            if (dbDepartment == null) return NotFound();
            _context.Departments.Remove(dbDepartment);
            await _context.SaveChangesAsync();
            return Ok();
        }
        
    }
}
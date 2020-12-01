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
        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentController(IMapper mapper,IDepartmentRepository departmentRepository)
        {
            _mapper = mapper;
            _departmentRepository = departmentRepository;
        }
        
        
        /// <summary>
        /// Get All Departments
        /// </summary>
        /// <returns></returns>
        // GET: api/<DepartmentController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var departments =await _departmentRepository.GetDepartmentsAsync();
            var mapperDepartments = _mapper.Map<IEnumerable<DepartmentReturnDto>>(departments);
            return Ok(mapperDepartments);
        }
        
        /// <summary>
        /// Get Department from Id
        /// </summary>
        /// <param name="id">for department</param>
        /// <returns></returns>
        // GET api/<DepartmentController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Department department = await _departmentRepository.GetDepartmentByIdAsync(id);
            if (department == null) return NotFound();
            var mapperDepartment = _mapper.Map<DepartmentReturnDto>(department);
            
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
            var mapperDepartment = _mapper.Map<Department>(departmentCreateDto);
            await _departmentRepository.CreateDepartmentAsync(mapperDepartment);
            return Ok(mapperDepartment);
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
            var mapperDepartment = _mapper.Map<Department>(departmentUpdateDto);
            var department= await _departmentRepository.UpdateDepartmentAsync(mapperDepartment);
            if (department == null) return BadRequest();
           
            return Ok(department);
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
            Department department = await _departmentRepository.DeleteDepartmentAsync(id);
            if (department == null) return NotFound();
            return Ok();
        }
        
    }
}
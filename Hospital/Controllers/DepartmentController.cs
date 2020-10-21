using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hospital.BLL.DTO;
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
        public DepartmentController(DataContext context)
        {
            _context=context;
        }
        
        
        /// <summary>
        /// Get All Departments
        /// </summary>
        /// <returns></returns>
        // GET: api/<DepartmentController>
        [HttpGet]
        public ActionResult<IEnumerable<Department>> Get()
        {
            return Ok(_context.Departments.ToList());
        }
        
        /// <summary>
        /// Get Department from Id
        /// </summary>
        /// <param name="id">for department</param>
        /// <returns></returns>
        // GET api/<DepartmentController>/5
        [HttpGet("{id}")]
        public ActionResult<Department> Get(int id)
        {
            Department department = _context.Departments.FirstOrDefault(p => p.Id == id);
            if (department == null) return NotFound();
            
            return Ok(department);
        }
        
        /// <summary>
        /// Create new Department
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        // POST api/<DepartmentController>
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Department department)
        {
            if (!ModelState.IsValid) return BadRequest();
            
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
        public async Task<ActionResult<Department>> Update(int id, [FromBody] Department department)
        {
            if (id != department.Id) return BadRequest();
            Department dbdepartment = _context.Departments.FirstOrDefault(p => p.Id == id);
            if (dbdepartment == null) return NotFound();

            dbdepartment.Name = department.Name;
            dbdepartment.Description = dbdepartment.Description;
            await _context.SaveChangesAsync();
            return Ok(dbdepartment);
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
            Department dbdepartment = _context.Departments.FirstOrDefault(p => p.Id == id);
            if (dbdepartment == null) return NotFound();
            _context.Departments.Remove(dbdepartment);
            await _context.SaveChangesAsync();
            return Ok();
        }
        
    }
}
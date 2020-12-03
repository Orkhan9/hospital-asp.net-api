using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hospital.BLL.DTO.Service;
using Hospital.DAL;
using Hospital.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ServiceController(DataContext context,IMapper mapper)
        {
            _context=context;
            _mapper = mapper;
        }
        
        
        /// <summary>
        /// Get All Services
        /// </summary>
        /// <returns></returns>
        // GET: api/<ServiceController>
        [HttpGet]
        public ActionResult<IEnumerable<ServiceReturnDto>> Get()
        {
            return Ok(_context.Services.ToList());
        }
        
        /// <summary>
        /// Get Service from Id
        /// </summary>
        /// <param name="id">for Service </param>
        /// <returns></returns>
        // GET api/<ServiceController>/5
        [HttpGet("{id}")]
        public ActionResult<Service> Get(int id)
        {
            Service service  = _context.Services.FirstOrDefault(p => p.Id == id);
            if (service == null) return NotFound();
            
            return Ok(service);
        }
        
        /// <summary>
        /// Create new Service
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        // POST api/<ServiceController>
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ServiceCreateDto serviceCreateDto)
        {
            Service service = new Service
            {
                Name = serviceCreateDto.Name,
                Description = serviceCreateDto.Description,
                ShortDesc = serviceCreateDto.ShortDesc
            };
            
            await _context.AddAsync(service);
            await _context.SaveChangesAsync();
            return Ok(service);
        }
        
        /// <summary>
        /// Update Service
        /// </summary>
        /// <param name="id"></param>
        /// <param name="service"></param>
        /// <returns></returns>
        // PUT api/<ServiceController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Department>> Update(int id, [FromBody] ServiceUpdateDto serviceUpdateDto)
        {
            if (id != serviceUpdateDto.Id) return BadRequest();
            Service dbservice = _context.Services.FirstOrDefault(p => p.Id == id);
            if (dbservice == null) return NotFound();

            dbservice.Name = serviceUpdateDto.Name;
            dbservice.Description = serviceUpdateDto.Description;
            dbservice.ShortDesc = serviceUpdateDto.ShortDesc;
            await _context.SaveChangesAsync();
            return Ok(dbservice);
        }
        
        /// <summary>
        /// Delete Service
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE api/<ServiceController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Service dbservice = _context.Services.FirstOrDefault(p => p.Id == id);
            if (dbservice == null) return NotFound();
            _context.Services.Remove(dbservice);
            await _context.SaveChangesAsync();
            return Ok();
        }
        
    }
}
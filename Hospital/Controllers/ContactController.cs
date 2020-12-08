using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hospital.BLL.DTO;
using Hospital.BLL.DTO.Appointment;
using Hospital.DAL;
using Hospital.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ContactController(DataContext context,IMapper mapper)
        {
            _context=context;
            _mapper = mapper;
        }
        /// <summary>
        /// Get All Contacts
        /// </summary>
        /// <returns></returns>
        //GET: api/<ContactController>
        [HttpGet]
        public ActionResult<IEnumerable<Contact>> Get()
        {
            var contacts = _context.Contacts.ToList();
            
            return Ok(contacts);
        }

        /// <summary>
        /// Get Contact from Id
        /// </summary>
        /// <param name="id">for contact</param>
        /// <returns></returns>
        //GET api/<ContactController>/5
        [HttpGet("{id}")]
        public ActionResult<Contact> Get(int id)
        {
            var contact = _context.Contacts.FirstOrDefault(p => p.Id == id);
            if (contact == null) return NotFound();
            
            return Ok(contact);
        }

        /// <summary>
        /// Create new Contact
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns></returns>
        // POST api/<ContactController>
        [HttpPost]
        public async Task<ActionResult> Create([FromForm] ContactCreateDto contactCreateDto)
        {
            Contact contact = new Contact
            {
                Name = contactCreateDto.Name,
                Email = contactCreateDto.Email,
                Phone = contactCreateDto.Phone,
                Subject = contactCreateDto.Subject,
                Message = contactCreateDto.Message
            };
           
            await _context.AddAsync(contact);
            await _context.SaveChangesAsync();
            return Ok(contact);
        }
        
        /// <summary>
        /// Delete Contact
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE api/<ContactController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var dbContact = _context.Contacts.FirstOrDefault(p => p.Id == id);
            if (dbContact == null) return NotFound();
            _context.Contacts.Remove(dbContact);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
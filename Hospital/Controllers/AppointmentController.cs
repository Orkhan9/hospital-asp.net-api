using System;
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
    public class AppointmentController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public AppointmentController(DataContext context,IMapper mapper)
        {
            _context=context;
            _mapper = mapper;
        }
        /// <summary>
        /// Get All Appointments
        /// </summary>
        /// <returns></returns>
        //GET: api/<AppointmentController>
        [HttpGet]
        public ActionResult<IEnumerable<AppointmentDto>> Get()
        {
            List<Appointment> appointments = _context.Appointments.Include(d => d.Doctor).ToList();
            var mapperappointments = _mapper.Map<IEnumerable<Appointment>,IEnumerable<AppointmentDto>>(appointments);
            return Ok(mapperappointments);
        }

        /// <summary>
        /// Get Appointment from Id
        /// </summary>
        /// <param name="id">for appointment</param>
        /// <returns></returns>
        //GET api/<AppointmentController>/5
        [HttpGet("{id}")]
        public ActionResult<AppointmentDto> Get(int id)
        {
            Appointment appointment = _context.Appointments.Include(d=>d.Doctor)
                .FirstOrDefault(p => p.Id == id);
            if (appointment == null) return NotFound();
            var mapperappointment = _mapper.Map<Appointment, AppointmentDto>(appointment);
            
            return Ok(mapperappointment);
        }

        /// <summary>
        /// Create new Appointment
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns></returns>
        // POST api/<AppointmentController>
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Appointment appointment)
        {
            if (!ModelState.IsValid) return BadRequest();
           
            await _context.AddAsync(appointment);
            await _context.SaveChangesAsync();
            return Ok(appointment);
        }
        
        /// <summary>
        /// Update Appointment
        /// </summary>
        /// <param name="id"></param>
        /// <param name="appointment"></param>
        /// <returns></returns>
        // PUT api/<AppointmentController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Appointment>> Update(int id, [FromBody] Appointment appointment)
        {
            if (id != appointment.Id) return BadRequest();
            Appointment dbappointment = _context.Appointments.Include(d=>d.Doctor)
                .FirstOrDefault(p => p.Id == id);
            if (dbappointment == null) return NotFound();

            dbappointment.Name = appointment.Name;
            dbappointment.Email = appointment.Email;
            dbappointment.Phone = appointment.Phone;
            dbappointment.DoctorId = appointment.DoctorId;
            dbappointment.Message = appointment.Message;
            await _context.SaveChangesAsync();
            return Ok(dbappointment);
        }

        /// <summary>
        /// Delete Appointment
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE api/<AppointmentController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Appointment dbAppointment = _context.Appointments.FirstOrDefault(p => p.Id == id);
            if (dbAppointment == null) return NotFound();
            _context.Appointments.Remove(dbAppointment);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
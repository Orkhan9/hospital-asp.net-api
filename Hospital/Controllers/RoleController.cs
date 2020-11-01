using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Hospital.BLL.DTO;
using Hospital.DAL;
using Hospital.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController: ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public RoleController(DataContext context,IMapper mapper)
        {
            _context=context;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Role>> Get()
        {
            List<Role> roles = _context.Roles.ToList();
          
            return Ok(roles);
        }
    }
}
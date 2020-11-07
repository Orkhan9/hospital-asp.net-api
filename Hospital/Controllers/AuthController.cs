using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Hospital.BLL.DTO;
using Hospital.DAL;
using Hospital.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Hospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;
        public AuthController(IAuthRepository repo,IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }
        
        [HttpPost("register")]
        public async Task<IActionResult>Register(UserForRegisterDto userForRegisterDto )
        {
            
            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();
            if (await _repo.UserExists(userForRegisterDto.Username))
            {
                return BadRequest("user already exists");
            }
            var newUser = new User
            {
                Name = userForRegisterDto.Username
                
                
            };
            var createdUser = _repo.Register(newUser,userForRegisterDto.Email, userForRegisterDto.Password,userForRegisterDto.RoleId);
           //return Ok(createdUser);
            return StatusCode(201);
        }
        
        [HttpPost("login")]
        public async Task<IActionResult>Login(UserForLoginDto userForLoginDto)
        {
            var userFromRepo =await _repo.Login(userForLoginDto.Username.ToLower(), userForLoginDto.Password,userForLoginDto.Role);
            if (userFromRepo == null)
                return Unauthorized();
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name,userFromRepo.Name),
                new Claim("role",userFromRepo.Role.Name)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config
                .GetSection("Appsettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriber = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials=creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriber);
            return Ok(new
            {
                token = tokenHandler.WriteToken(token)
            });
    
        }
    }
    
}
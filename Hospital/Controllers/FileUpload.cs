using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class FileUpload : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Upload([FromForm]IFormFile file)
        {
            try
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/image",file.Name);
                FileStream stream=new FileStream(path,FileMode.Create);
                await file.CopyToAsync(stream);
                return Ok("okey");
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
    }
}
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
        public async Task<IActionResult> Upload(IFormFile file)
        {
            try
            {
                if (file.Length>0)
                {
                    string newpath = Guid.NewGuid() + file.FileName;
                    using (FileStream filestream=System.IO.File.Create((newpath)))
                    {
                        await file.CopyToAsync(filestream);
                        filestream.Flush();
                       
                    }
                    
                }
                // string newpath = Guid.NewGuid() + file.Name+file.ContentType;
                // string path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/images",newpath);
                // FileStream stream=new FileStream(path,FileMode.Create);
                // await file.CopyToAsync(stream);
                // return Ok("okey");
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
            return Ok("lorem");

        }
    }
}
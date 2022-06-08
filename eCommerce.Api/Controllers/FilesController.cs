using eCommerce.Api.DTOs;
using eCommerce.Core.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        // POST api/files
        [HttpPost("")]
        public async Task<ActionResult<ResponseDTO>> Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Files", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {

                    var uniqueFileName = UniqueFileNameGenerator.GetUniqueFileName(file.FileName);
                    var fullPath = Path.Combine(pathToSave, uniqueFileName);
                    var dbPath = Path.Combine(folderName, uniqueFileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok(ResponseDTO.GenerateResponse(dbPath));
                }
                else
                {
                    return BadRequest(ResponseDTO.GenerateResponse(null, false, "İşlem başarısız!"));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ResponseDTO.GenerateResponse(null, false, ex.ToString()));
            }
        }
    }
}

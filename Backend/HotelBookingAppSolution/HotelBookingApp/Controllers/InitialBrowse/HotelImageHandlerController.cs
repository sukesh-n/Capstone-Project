using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HotelBookingApp.Services.BlobService;
using System.IO;
using System.Threading.Tasks;

namespace HotelBookingApp.Controllers.InitialBrowse
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelImageHandlerController : ControllerBase
    {
        private readonly HotelImageBlobService _blobService;

        public HotelImageHandlerController(HotelImageBlobService blobService)
        {
            _blobService = blobService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage([FromForm] IFormFile file, [FromQuery] string fileName)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            if (string.IsNullOrEmpty(fileName))
            {
                return BadRequest("File name is required.");
            }

            try
            {
                // Ensure the file name is safe and unique, if necessary
                using (var stream = file.OpenReadStream())
                {
                    var imageUrl = await _blobService.UploadImageAsync(stream, fileName);
                    return Ok(new { Url = imageUrl });
                }
            }
            catch (Exception ex)
            {
                // Log exception if necessary
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error uploading image: {ex.Message}");
            }
        }
    }
}

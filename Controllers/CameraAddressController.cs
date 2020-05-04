using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace HackDayApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CameraAddressController : ControllerBase
    {

        private readonly ILogger<CameraAddressController> _logger;
        private readonly CameraAddressService _service;

        public CameraAddressController(ILogger<CameraAddressController> logger, CameraAddressService service)
        {
            _logger = logger;
            _service = service;
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGeocode(long id)
        {
            var a = await _service.GetHouseInfo(id);
            return Ok(a);
        }

        [HttpPost("/cameras")]
        public async Task<IActionResult> UploadCameraAddress(IFormFile file)
        {
            var result = await _service.SaveCameras(file);
            return Ok(result);
        }
        
        [HttpPost("/clients")]
        public async Task<IActionResult> PostFile(List<IFormFile> files)
        {
            foreach (var file in files)
            {
                var result = await _service.SaveCameras(file);
            
                return Ok(result);
            }

            return null;
        }
    }
}
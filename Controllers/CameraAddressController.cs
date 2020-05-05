using System.Threading.Tasks;
using HackDayApi.Services;
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
        
        [HttpGet("/houses")]
        public IActionResult LoadHouses()
        {
            var a = _service.GetHousesInfo();
            return Ok(a);
        }
        [HttpGet("/houses/{id}")]
        public IActionResult LoadHouse(long id)
        {
            var a = _service.GetHouseInfo(id);
            return Ok(a);
        }
        [HttpGet("/entrances/{id}")]
        public IActionResult LoadEntrance(long id)
        {
            var a = _service.GetEntranceInfo(id);
            return Ok(a);
        }
        [HttpPost("/cameras")]
        public async Task<IActionResult> UploadCameras(IFormFile file)
        {
            await _service.SaveCameras(file);
            return Ok("success");
        }
        
        [HttpPost("/clients")]
        public async Task<IActionResult> UploadClients(IFormFile file)
        {
            await _service.SaveClients(file);
            return Ok("success");
        }
    }
}
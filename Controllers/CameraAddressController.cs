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

        private readonly CameraAddressService _service;

        public CameraAddressController(CameraAddressService service)
        {
            _service = service;
        }
        
        [HttpGet("/houses")]
        public async Task<IActionResult> LoadHouses()
        {
            var a = await _service.GetHousesInfo();
            return Ok(a);
        }
        [HttpGet("/houses/{id}")]
        public async Task<IActionResult> LoadHouse(long id)
        {
            var a = await _service.GetHouseInfo(id);
            return Ok(a);
        }
        [HttpGet("/entrances/{id}")]
        public async Task<IActionResult> LoadEntrance(long id)
        {
            var a = await _service.GetEntranceInfo(id);
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
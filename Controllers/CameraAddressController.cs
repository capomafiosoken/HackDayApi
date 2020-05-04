using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using ExcelDataReader;
using HackDayApi.Models;
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
        
        [HttpGet]
        public async Task<IActionResult> GetGeocode()
        {
            var a = await Geocoder.GeocodeAddress("12-й микрорайон, 11, подъезд 6");
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
           

            return Ok(files.Count);
        }
    }
}
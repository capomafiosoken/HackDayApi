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

        public CameraAddressController(ILogger<CameraAddressController> logger)
        {
            _logger = logger;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetGeocode()
        {
            var a = await Geocoder.GeocodeAddress("12-й микрорайон, 11, подъезд 6");
            return Ok(a);
        }

        [HttpPost("/cameras")]
        public async Task<IActionResult> UploadCameraAddress(List<IFormFile> files)
        {
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    // await using var stream = System.IO.File.Create(file.FileName);
                    // await file.CopyToAsync(stream);
                    var a =file.OpenReadStream();
                    var reader = ExcelReaderFactory.CreateReader(a).AsDataSet();
                    foreach (DataTable dataTable in reader.Tables)
                    {
                        foreach (DataRow dataRow in dataTable.Rows)
                        {
                            var House = new House();
                            House.Address = dataRow[0].ToString();
                            var response = await Geocoder.GeocodeAddress(dataRow[0].ToString());
                            House.Latitude = response.Data.Items[0].Coordinates[0];
                            House.Longitude = response.Data.Items[0].Coordinates[1];
                            var Entrance = new Models.Entrance();
                            Entrance.Number = int.Parse(dataRow[1].ToString());
                            Entrance.CameraNumber = int.Parse(dataRow[2].ToString());
                            Entrance.Latitude = response.Data.Items[0].Entrances[Entrance.Number].Coordinates[0];
                            Entrance.Longitude = response.Data.Items[0].Entrances[Entrance.Number].Coordinates[1];

                        }
                    }
                }
            }
            return Ok(files.Count);
        }
        
        [HttpPost("/clients")]
        public async Task<IActionResult> PostFile(List<IFormFile> files)
        {
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    // await using var stream = System.IO.File.Create(file.FileName);
                    // await file.CopyToAsync(stream);
                    var a =file.OpenReadStream();
                    var reader = ExcelReaderFactory.CreateReader(a).AsDataSet();
                    foreach (DataTable dataTable in reader.Tables)
                    {
                        foreach (DataRow dataRow in dataTable.Rows)
                        {
                            var Client = new Client();
                            Client.FullName = dataRow[0].ToString();
                            Client.ApartmentNumber = int.Parse(dataRow[3].ToString());
                            Client.PhoneNumber = dataRow[4].ToString();
                            Client.TariffPlan = dataRow[5].ToString();
                            Console.WriteLine(dataRow[0]);
                        }
                    }
                }
            }

            return Ok(files.Count);
        }
    }
}
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using ExcelDataReader;
using HackDayApi.Context;
using HackDayApi.Models;
using Microsoft.AspNetCore.Http;

namespace HackDayApi
{
    public class CameraAddressService
    {
        private readonly CameraAddressContext _context;

        public CameraAddressService(CameraAddressContext context)
        {
            _context = context;
        }

        public async Task<List<House>> SaveCameras(IFormFile file)
        {
            var a = file.OpenReadStream();
            var reader = ExcelReaderFactory.CreateReader(a).AsDataSet();
            foreach (DataTable dataTable in reader.Tables)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    var house = new House();
                    house.Address = dataRow[0].ToString();
                    var response = await Geocoder.GeocodeAddress(dataRow[0].ToString());
                    house.Latitude = response.Data.Items[0].Coordinates[0];
                    house.Longitude = response.Data.Items[0].Coordinates[1];
                    var EntrancesList = new List<Models.Entrance>();
                    for (int i = 0 ; i < response.Data.Items[0].Entrances.Length;i++)
                    {
                        var Entrance  = new Models.Entrance();
                        if (i==int.Parse(dataRow[1].ToString()))
                        {
                            Entrance.CameraNumber = int.Parse(dataRow[2].ToString());
                        }
                        else
                        {
                            Entrance.CameraNumber = 0;
                        }
                       
                        Entrance.Number = i;
                        Entrance.Latitude = Entrance.Latitude;
                        Entrance.Longitude = Entrance.Longitude;
                        EntrancesList.Add(Entrance);
                    }

                }
            }

            return null;
        }
    }
}
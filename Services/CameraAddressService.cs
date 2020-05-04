using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ExcelDataReader;
using HackDayApi.Context;
using HackDayApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace HackDayApi.Services
{
    public class CameraAddressService
    {
        private readonly CameraAddressContext _context;

        public CameraAddressService(CameraAddressContext context)
        {
            _context = context;
        }
        
        public async Task SaveCameras(IFormFile file)
        {
            var a = file.OpenReadStream();
            var reader = ExcelReaderFactory.CreateReader(a).AsDataSet();
            foreach (DataTable dataTable in reader.Tables)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    var address = dataRow[0].ToString();
                    var house = await _context.Houses.FirstOrDefaultAsync(x => x.Address == address);
                    if (house!=null)
                    {
                        house = new House
                        {
                            Address = address
                        };
                        var response = await Geocoder.GeocodeAddress(house.Address);
                        house.Latitude = response.Data.Items[0].Coordinates[0];
                        house.Longitude = response.Data.Items[0].Coordinates[1];
                        var entrancesList = new List<Models.Entrance>();
                        for (var i = 0; i < response.Data.Items[0].Entrances.Length; i++)
                        {
                            entrancesList.Add(new Models.Entrance
                            {
                                Number = i + 1,
                                Latitude = response.Data.Items[0].Entrances[i].Coordinates[0],
                                Longitude = response.Data.Items[0].Entrances[i].Coordinates[1]
                            });
                        }
                        await _context.Houses.AddAsync(house);
                        await _context.Entrances.AddRangeAsync(entrancesList);
                        await _context.SaveChangesAsync();
                    }
                    
                    var enter = await _context.Entrances.FirstOrDefaultAsync(x=>x.HouseId == house.Id && x.Number == int.Parse(dataRow[1].ToString()));
                    enter.CameraNumber = int.Parse(dataRow[2].ToString());
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task SaveClients(IFormFile file)
        {
            var a = file.OpenReadStream();
            var reader = ExcelReaderFactory.CreateReader(a).AsDataSet();
            foreach (DataTable dataTable in reader.Tables)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    string address = dataRow[1].ToString();
                    var house = await _context.Houses.FirstOrDefaultAsync(x => x.Address == address);
                    if (house != null)
                    {
                        house = new House
                        {
                            Address = address
                        };
                        var response = await Geocoder.GeocodeAddress(house.Address);
                        house.Latitude = response.Data.Items[0].Coordinates[0];
                        house.Longitude = response.Data.Items[0].Coordinates[1];
                        var entrancesList = new List<Models.Entrance>();
                        for (var i = 0; i < response.Data.Items[0].Entrances.Length; i++)
                        {
                            entrancesList.Add(new Models.Entrance
                            {
                                Number = i + 1,
                                Latitude = response.Data.Items[0].Entrances[i].Coordinates[0],
                                Longitude = response.Data.Items[0].Entrances[i].Coordinates[1]
                            });
                        }

                        await _context.Houses.AddAsync(house);
                        await _context.Entrances.AddRangeAsync(entrancesList);
                        await _context.SaveChangesAsync();
                    }
                    var enter = await _context.Entrances.FirstOrDefaultAsync(x=>x.HouseId == house.Id && x.Number == int.Parse(dataRow[2].ToString()));
                    var client = new Client
                    {
                        EntranceId = enter.Id,
                        FullName = dataRow[0].ToString(),
                        ApartmentNumber = int.Parse(dataRow[3].ToString()),
                        PhoneNumber = dataRow[4].ToString(),
                        TariffPlan = dataRow[5].ToString()
                    };

                    await _context.Clients.Upsert(client).On(x => new {x.EntranceId , x.ApartmentNumber}).RunAsync();
                }
            }
        }

        public House GetHouseInfo(long id)
        {
            var a = _context.Houses.Where(x => x.Id == id).Include(x=>x.Entrances).ThenInclude(x=>x.Clients).FirstOrDefault();
            return a;
        }
        public List<House> GetHousesInfo()
        {
            var a =  _context.Houses.Include(x=>x.Entrances).ThenInclude(x=>x.Clients).ToList();
            return a;
        }
    }
}
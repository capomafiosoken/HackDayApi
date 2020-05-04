using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using ExcelDataReader;
using HackDayApi.Context;
using HackDayApi.Models;
using Microsoft.AspNetCore.Http;

namespace HackDayApi
{
    public class ClientAddressService
    {
        private readonly CameraAddressContext _context;

        public ClientAddressService(CameraAddressContext context)
        {
            _context = context;
        }

        public async Task<List<House>> SaveClients(IFormFile file)
        {
            var a = file.OpenReadStream();
            var reader = ExcelReaderFactory.CreateReader(a).AsDataSet();
            foreach (DataTable dataTable in reader.Tables)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    var Client = new Client();
                    Client.FullName = dataRow[0].ToString();
                    //var address = dataRow[1].ToString();
                    //var entrance_id = int.Parse(dataRow[2].ToString());
                    Client.ApartmentNumber = int.Parse(dataRow[3].ToString());
                    Client.PhoneNumber = dataRow[4].ToString();
                    Client.TariffPlan = dataRow[5].ToString();
                }
            }

            return null;
        }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HackDayApi.Models
{
    public class Client
    {
        [Key] [Column("id")] public long Id { get; set; }
        [Column("full_name")] public string FullName { get; set; }
        [Column("phone_number")] public string PhoneNumber { get; set; }
        [Column("entrance_id")] public long EntranceId { get; set; }
        [Column("apartment_number")] public int ApartmentNumber { get; set; }
        [Column("tariff_plan")] public string TariffPlan { get; set; }
    }    
}
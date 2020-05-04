using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HackDayApi.Models
{
    public class Entrance
    {
        [Key] [Column("id")] public long Id { get; set; }
        [Column("house_id")] public long HouseId { get; set; }
        [Column("number")] public int Number { get; set; }
        [Column("latitude")] public double Latitude { get; set; }
        [Column("longitude")] public double Longitude { get; set; }
        [Column("camera_number")] public int camerNumber { get; set; }
    }
}
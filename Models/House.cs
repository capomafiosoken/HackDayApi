using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HackDayApi.Models
{
    [Table("house")]
    public class House
    {
        [Key] [Column("id")] public long Id { get; set; }
        [Column("address")] public string Address { get; set; }
        [Column("latitude")] public double Latitude { get; set; }
        [Column("longitude")] public double Longitude { get; set; }
        public List<Entrance> Entrances { get; set; }
    }
}
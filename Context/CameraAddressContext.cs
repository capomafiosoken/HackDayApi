using HackDayApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HackDayApi.Context
{
    public abstract class CameraAddressContext: DbContext
    {
        protected CameraAddressContext(DbContextOptions<CameraAddressContext> options) : base(options)
        {
            
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Entrance> Entrances { get; set; }
        public DbSet<House> Houses { get; set; }
        
    }
}

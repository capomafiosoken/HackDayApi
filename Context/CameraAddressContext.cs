using HackDayApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HackDayApi.Context
{
    public class CameraAddressContext: DbContext
    {
        public CameraAddressContext(DbContextOptions<CameraAddressContext> options) : base(options)
        {
            
        }
        public DbSet<Models.Client> Clients { get; set; }
        public DbSet<Models.Entrance> Entrances { get; set; }
        public DbSet<Models.House> Houses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<House>().HasMany(x => x.Entrances).WithOne().HasForeignKey(x => x.HouseId)
                .HasPrincipalKey(x => x.Id);
            modelBuilder.Entity<Models.Entrance>().HasMany(x => x.Clients).WithOne().HasForeignKey(x => x.EntranceId)
                .HasPrincipalKey(x => x.Id);
        }
    }
}

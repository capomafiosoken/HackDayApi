using Microsoft.EntityFrameworkCore;

namespace HackDayApi.Context
{
    public abstract class Context: DbContext
    {
        protected Context()
        {
            base.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected Context(DbContextOptions options) : base(options)
        {
            base.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                "Server = localhost; Database = postgres; Port=5432; User ID = postgres; Password = aibek007; Search Path = hackday; Integrated Security=true; Pooling=true;");
        }
    }
}

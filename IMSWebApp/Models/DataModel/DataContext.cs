using Microsoft.EntityFrameworkCore;

namespace IMSWebApp.Models.DataModel
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opts): base(opts) { }
        public DbSet<SPECIES> SPECIES { get; set; }
        public DbSet<TANK_LOG> TANK_LOG { get; set; }
        public DbSet<DAILY_LOG> DAILY_LOG { get; set; }
        public DbSet<MORTALITY> MORTALITY { get; set; }
    }
}

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


        /* How to set primary key of a table in a database
           https://docs.microsoft.com/en-us/ef/core/modeling/relational/primary-keys */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.HasDefaultSchema("dbo");

            /* Setup primary key for SPECIES table*/
            //modelBuilder.Entity<SPECIES>().HasKey(t => t.ID_PK); // Primary Key

            /* Setup primary key for TANK_LOG table*/
            //modelBuilder.Entity<TANK_LOG>().HasKey(t => t.ID_PK);

            /* Establish the relationship between table SPECIES and TANK_LOG */
            /* https://docs.microsoft.com/en-us/ef/core/modeling/relationships  */

            modelBuilder.Entity<TANK_LOG>().HasOne(l => l.SPECIES)
                                           .WithMany(s => s.TANK_LOG)
                                           .HasForeignKey(l => l.SPECIES_FK);


            /* Setup primary key for DAILY_LOG table*/
            //modelBuilder.Entity<DAILY_LOG>().HasKey(t => t.ID_PK);

            /* Setup the foreign key for DAILY_LOG table */
            modelBuilder.Entity<DAILY_LOG>().HasOne(t => t.TANK_LOG)
                                .WithOne().HasForeignKey<DAILY_LOG>(t => t.LOG_FK);
            modelBuilder.Entity<DAILY_LOG>().HasOne(t => t.MORTALITY)
                                .WithOne().HasForeignKey<DAILY_LOG>(t => t.REASON_FK);

            /* Setup primary key for DAILY_LOG table*/
            //modelBuilder.Entity<MORTALITY>().HasKey(t => t.ID_PK);

            modelBuilder.Entity<MORTALITY>().HasMany(t => t.DAILY_LOG)
                        .WithOne(l => l.MORTALITY).HasForeignKey(l => l.REASON_FK) ;
        }
    }
}

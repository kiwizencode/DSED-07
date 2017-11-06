using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IMSWebApp.Models
{
    public partial class IMSystemContext : DbContext
    {
        public IMSystemContext(DbContextOptions<IMSystemContext> opts) : base(opts) { }
        public virtual DbSet<DailyLog> DailyLog { get; set; }
        public virtual DbSet<Mortality> Mortality { get; set; }
        public virtual DbSet<Species> Species { get; set; }
        public virtual DbSet<TankLog> TankLog { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=IMSystem;Integrated Security=True");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DailyLog>(entity =>
            {
                entity.HasKey(e => e.IdPk);

                entity.ToTable("DAILY_LOG");

                entity.Property(e => e.IdPk).HasColumnName("ID_PK");

                entity.Property(e => e.Comment)
                    .HasColumnName("COMMENT")
                    .HasMaxLength(100);

                entity.Property(e => e.DailyDate)
                    .HasColumnName("DAILY_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.LogFk).HasColumnName("LOG_FK");

                entity.Property(e => e.Qty).HasColumnName("QTY");

                entity.Property(e => e.ReasonFk).HasColumnName("REASON_FK");

                entity.HasOne(d => d.LogFkNavigation)
                    .WithMany(p => p.DailyLog)
                    .HasForeignKey(d => d.LogFk)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ReasonFkNavigation)
                    .WithMany(p => p.DailyLog)
                    .HasForeignKey(d => d.ReasonFk)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Mortality>(entity =>
            {
                entity.HasKey(e => e.IdPk);

                entity.ToTable("MORTALITY");

                entity.Property(e => e.IdPk).HasColumnName("ID_PK");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnName("TEXT")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Species>(entity =>
            {
                entity.HasKey(e => e.IdPk);

                entity.ToTable("SPECIES");

                entity.Property(e => e.IdPk).HasColumnName("ID_PK");

                entity.Property(e => e.Common)
                    .IsRequired()
                    .HasColumnName("COMMON")
                    .HasMaxLength(100);

                entity.Property(e => e.Scientific)
                    .IsRequired()
                    .HasColumnName("SCIENTIFIC")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TankLog>(entity =>
            {
                entity.HasKey(e => e.IdPk);

                entity.ToTable("TANK_LOG");

                entity.HasIndex(e => e.SpeciesFk);

                entity.Property(e => e.IdPk).HasColumnName("ID_PK");

                entity.Property(e => e.Comment)
                    .HasColumnName("COMMENT")
                    .HasMaxLength(100);

                entity.Property(e => e.PeriodDate)
                    .HasColumnName("PERIOD_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Qty).HasColumnName("QTY");

                entity.Property(e => e.SpeciesFk).HasColumnName("SPECIES_FK");

                entity.Property(e => e.TankId).HasColumnName("TANK_ID");

                entity.HasOne(d => d.SpeciesFkNavigation)
                    .WithMany(p => p.TankLog)
                    .HasForeignKey(d => d.SpeciesFk)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }
    }
}

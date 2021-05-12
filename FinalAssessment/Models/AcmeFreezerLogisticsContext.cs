using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FinalAssessment.Models​
{
    public partial class AcmeFreezerLogisticsContext : DbContext
    {
        public AcmeFreezerLogisticsContext()
        {
        }

        public AcmeFreezerLogisticsContext(DbContextOptions<AcmeFreezerLogisticsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DriverDetail> DriverDetails { get; set; }

        public virtual DbSet<TruckDetails> TruckDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AcmeFreezerLogistics;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<DriverDetail>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FirstName)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.LastName)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.LicenseExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.LicenseNumber).HasMaxLength(50);
            });
            modelBuilder.Entity<TruckDetails>(entity =>
            {
                entity.ToTable("TblTruckDetails");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.TruckRGNumber)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.TruckFitnessExpiry)
                    .HasMaxLength(50)
                    .IsFixedLength(true);
                entity.Property(e => e.TruckModel)
                 .HasMaxLength(50)
                 .IsFixedLength(true);

                entity.Property(e => e.TruckHaulingCapacity)
                    .HasMaxLength(50)
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

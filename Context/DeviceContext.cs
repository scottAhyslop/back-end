using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using back_end.Models;

#nullable disable

namespace back-end
{
    public partial class DevicveContext : DbContext
    {
        public DevicveContext()
        {
        }

        public DevicveContext(DbContextOptions<DevicveContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Device> Devices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Device>(entity =>
            {
                entity.Property(e => e.DeviceIconPath)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DeviceName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DeviceOs)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DeviceOS");

                entity.Property(e => e.DeviceOsiconPath)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DeviceOSIconPath");

                entity.Property(e => e.DeviceStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DeviceType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Temperature)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TimeInUse)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

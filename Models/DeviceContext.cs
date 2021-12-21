using Microsoft.EntityFrameworkCore;

namespace back_end.Models
{
    public class DeviceContext: DbContext
    {
        //blank constructor
        public DeviceContext()
        {
        }

        public DeviceContext(DbContextOptions<DeviceContext> options): base(options)
        {}
        public virtual DbSet<Device> Devices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //fallback if db connection fails, remove for production
            options.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Integrated Security=True;");        }

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

                entity.Property(e => e.DeviceOS)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DeviceOS");

                entity.Property(e => e.DeviceOSIconPath)
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
        }
    }

    
}

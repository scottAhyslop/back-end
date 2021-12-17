using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace back_end.Models
{
    public class DeviceContext : DbContext
    {
        public DeviceContext (DbContextOptions<DeviceContext> options)
            : base(options)
        {
        }

        public DbSet<Device> Devices{ get; set; }
    }
}
    


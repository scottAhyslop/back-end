using Microsoft.EntityFrameworkCore;

namespace back_end.Models
{
    public class BackEndContext: DbContext
    {
        public BackEndContext(DbContextOptions<BackEndContext> options): base(options)
        {

        }
        public DbSet<Device> Devices { get; set; }

    }
}

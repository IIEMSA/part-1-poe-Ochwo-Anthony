using Microsoft.EntityFrameworkCore;

namespace ST10395938_CLDV6211_POEPart1.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 
        }

        public DbSet<Venues> Venues { get; set; }

        public DbSet<Events> Events { get; set; }

        public DbSet<Bookings> Bookings { get; set; }
    }
}

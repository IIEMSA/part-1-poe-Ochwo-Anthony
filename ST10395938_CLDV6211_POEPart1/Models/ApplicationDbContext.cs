using Microsoft.EntityFrameworkCore;

namespace ST10395938_CLDV6211_POEPart1.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }

        public DbSet<VenuesModel> Venues { get; set; } = null!;
        public DbSet<EventsModel> Events { get; set; } = null!;
        public DbSet<BookingsModel> Bookings { get; set; } = null!;
    }
}

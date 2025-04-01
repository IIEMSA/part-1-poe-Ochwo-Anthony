using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ST10395938_CLDV6211_POEPart1.Models
{
    public class EventsModel
    {
        [Key]
        public int EventId { get; set; }

        [Required]
        [StringLength(255)]
        public string EventName { get; set; } = string.Empty;

        [Required]
        public DateTime EventDate { get; set; }
        public string Description { get; set; } = string.Empty;

        [Required]
        [ForeignKey("Venue")]
        public int VenueId { get; set; }
        public VenuesModel Venues { get; set; } = new VenuesModel();
        public List<BookingsModel> Bookings { get; set; }

        public EventsModel() 
        {
            Bookings = new List<BookingsModel>();
        }

    }
}

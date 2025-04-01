using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ST10395938_CLDV6211_POEPart1.Models
{
    public class BookingsModel
    {
        [Key]
        public int BookingId { get; set; }

        [Required]
        [ForeignKey("Event")]
        public int EventId { get; set; }
        public required EventsModel Event { get; set; }

        [Required]
        [ForeignKey("Venue")]
        public int VenueId { get; set; }
        public required VenuesModel Venue { get; set; }

        [Required]
        public DateTime BookingDate { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ST10395938_CLDV6211_POEPart1.Models
{
    public class Events
    {
        // The code was adapted from "MVC, Entity Framework & SQL Azure" by Adeol Adisa
        [Key]
        public int EventId { get; set; }

        public string EventName { get; set; }

        public DateTime EventDate { get; set; }

        public string EventDescription { get; set; }

        public int VenueId { get; set; }

        [ForeignKey("VenueId")]
        public Venues? Venues { get; set; }

        public List<Bookings> Bookings { get; set; } = new();
    }
}

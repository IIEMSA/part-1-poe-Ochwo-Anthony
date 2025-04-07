using System.ComponentModel.DataAnnotations;

namespace ST10395938_CLDV6211_POEPart1.Models
{
    public class Venues
    {
        // The code was adapted from "MVC, Entity Framework & SQL Azure" by Adeol Adisa
        [Key]
        public int VenueId { get; set; }

        public string VenueName { get; set; }

        public string VenueLocation { get; set; }

        public int VenueCapacity { get; set; }

        public string ImageUrl { get; set; }

        public List<Events> Events { get; set; } = new();

        public List<Bookings> Bookings { get; set; } = new();

    }
}

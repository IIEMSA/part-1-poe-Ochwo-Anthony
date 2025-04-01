using System.ComponentModel.DataAnnotations;

namespace ST10395938_CLDV6211_POEPart1.Models
{
    public class VenuesModel
    {
        [Key]
        public int VenueId { get; set; }

        [Required]
        [StringLength(255)]
        public string VenueName { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]
        public string Location { get; set; } = string.Empty;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Capacity must be greater than 0")]
        public int Capacity { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public List<BookingsModel> Bookings { get; set; }

        public VenuesModel()
        {
            Bookings = new List<BookingsModel>();
        }
    }
}

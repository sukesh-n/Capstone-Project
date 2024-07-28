using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApp.Models.Guests
{
    public class GuestGenuineness
    {
        [Key]
        public int GuestId { get; set; }
        public int ContinuousCancellationCount { get; set; }
        public int TotalCancellationCount { get; set; }
        [ForeignKey("GuestId")]
        public Guest? Guest { get; set; }
    }
}

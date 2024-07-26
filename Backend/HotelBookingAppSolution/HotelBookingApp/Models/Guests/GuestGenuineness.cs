using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApp.Models.Guests
{
    public class GuestGenuineness
    {
        [ForeignKey("GuestId")]
        public int GuestId { get; set; }
        public int ContinuousCancellationCount { get; set; }
        public int TotalCancellationCount { get; set; }
    }
}

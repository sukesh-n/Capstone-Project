using HotelBookingApp.Models.Booking;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApp.Models.Bookings
{
    public class Cancellation
    {
        [Key]
        public int CancellationId { get; set; }
        public int BookingId { get; set; }
        public string CancellationReason { get; set; } = string.Empty;
        public DateTime CancellationDate { get; set; }
        public float RefundAmount { get; set; }
        public string CnacellationStatus { get; set; } = string.Empty;
        public string CancellationBy { get; set; } = string.Empty;
        public string RefundStatus { get; set; } = string.Empty;
        [ForeignKey("BookingId")]
        public BookingHistory? Booking { get; set; }

    }
}

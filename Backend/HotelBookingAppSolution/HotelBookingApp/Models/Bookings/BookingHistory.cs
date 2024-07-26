using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApp.Models.Booking
{
    public class BookingHistory
    {
        [Key]
        public int BookingId { get; set; }
        [Required]
        [ForeignKey("HotelBranchId")]
        public int HotelBranchId { get; set; }
        [Required]
        [ForeignKey("GuestId")]
        public int GuestId { get; set; }
        public string BookingStatus { get; set; } = string.Empty;
        public DateOnly CheckInDate { get; set; }
        public DateOnly CheckOutDate { get; set; }
        public TimeOnly CheckInTime { get; set; }
        public TimeOnly CheckOutTime { get; set; }
        public int NumberOfRooms { get; set; }
        [Required]
        [ForeignKey("RoomTypeId")]
        public string RoomTypeId { get; set; } = string.Empty;
        public int NumberOfAdults { get; set; }
        public int NumberOfChildren { get; set; }
        public string BookingType { get; set; } =string.Empty;
        public string PaymentStatus { get; set; } = string.Empty;
        public string CurrentInOutStatus { get; set; } = string.Empty;


    }
}

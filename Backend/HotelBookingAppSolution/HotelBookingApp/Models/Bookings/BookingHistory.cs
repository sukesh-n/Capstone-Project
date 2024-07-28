using HotelBookingApp.Models.Bookings;
using HotelBookingApp.Models.Guests;
using HotelBookingApp.Models.Hotels;
using HotelBookingApp.Models.Hotels.HotelBranches;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApp.Models.Booking
{
    public class BookingHistory
    {
        [Key]
        public int BookingId { get; set; }
        [Required]
        public int HotelBranchId { get; set; }
        [Required]
        public int GuestId { get; set; }
        public EnumBookingStatus BookingStatus { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public TimeSpan CheckInTime { get; set; }
        public TimeSpan CheckOutTime { get; set; }
        public int NumberOfRooms { get; set; }
        [Required]
        public int RoomTypeId { get; set; }
        public int NumberOfAdults { get; set; }
        public int NumberOfChildren { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }
        public EnumBookingTypes BookingType { get; set; }
        public EnumBookingPaymentStatus BookingPaymentStatus { get; set; }
        public EnumCurrentInOutStatus CurrentInOutStatus { get; set; }
        [ForeignKey("RoomTypeId")]
        public RoomType? RoomType { get; set; }
        [ForeignKey("GuestId")]
        public Guest? Guest { get; set; }
        [ForeignKey("HotelBranchId")]
        public HotelBranch? HotelBranch { get; set; }

    }
}

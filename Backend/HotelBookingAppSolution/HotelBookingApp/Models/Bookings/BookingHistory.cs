using HotelBookingApp.Models.Bookings;
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
        public EnumBookingStatus BookingStatus { get; set; }
        public DateOnly CheckInDate { get; set; }
        public DateOnly CheckOutDate { get; set; }
        public TimeOnly CheckInTime { get; set; }
        public TimeOnly CheckOutTime { get; set; }
        public int NumberOfRooms { get; set; }
        [Required]
        [ForeignKey("RoomTypeId")]
        public int RoomTypeId { get; set; }
        public int NumberOfAdults { get; set; }
        public int NumberOfChildren { get; set; }
        public float TotalAmount { get; set; }
        public EnumBookingTypes BookingType { get; set; }
        public EnumBookingPaymentStatus BookingPaymentStatus { get; set; }
        public EnumCurrentInOutStatus CurrentInOutStatus { get; set; }


    }
}

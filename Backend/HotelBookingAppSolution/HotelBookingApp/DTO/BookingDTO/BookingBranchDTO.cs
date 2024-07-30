using HotelBookingApp.Models.Bookings;

namespace HotelBookingApp.DTO.BookingDTO
{
    public class BookingBranchDTO
    {
        public int GuestId { get; set; }
        public int HotelBranchId { get; set; }
        public int RoomTypeId { get; set; }
        public int NumberOfRooms { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public TimeSpan CheckInTime { get; set; }
        public TimeSpan CheckOutTime { get; set; }
        public int NumberOfAdults { get; set; }
        public int NumberOfChildren { get; set; }
        public decimal TotalAmount { get; set; }
        public EnumBookingTypes BookingType { get; set; }
    }
}

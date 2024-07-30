using HotelBookingApp.Models.Booking;

namespace HotelBookingApp.DTO.BookingDTO
{
    public class BookingHistoryDTO
    {
        public int HotelBranchId { get; set; }
        public BookingHistory? BookingHistory { get; set; }
    }
}

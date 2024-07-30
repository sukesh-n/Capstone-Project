using HotelBookingApp.Models.Booking;
using HotelBookingApp.Models.Payments;

namespace HotelBookingApp.DTO.BookingDTO
{
    public class BookingHistoryUpdateDTO
    {
        public int BookingId { get; set; }
        public BookingHistory? BookingHistory { get; set; }

    }
}

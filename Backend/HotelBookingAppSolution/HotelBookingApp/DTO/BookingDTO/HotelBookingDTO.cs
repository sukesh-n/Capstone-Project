using HotelBookingApp.Models.Booking;
using HotelBookingApp.Models.Hotels;
using HotelBookingApp.Models.Hotels.HotelBranches;
using HotelBookingApp.Models.Payment;

namespace HotelBookingApp.DTO.BookingDTO
{
    public class HotelBookingDTO
    {
        public HotelBranch? Hotel { get; set; }
        public RoomType? RoomType { get; set; }
        public BookingHistory? BookingHistory { get; set; }
        public BookingPayment? BookingPayment { get; set; }

    }
}
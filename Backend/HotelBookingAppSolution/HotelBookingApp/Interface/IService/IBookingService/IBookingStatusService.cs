using HotelBookingApp.DTO.BookingDTO;
using HotelBookingApp.Models.Booking;

namespace HotelBookingApp.Interface.IService.IBookingService
{
    public interface IBookingStatusService
    {
        public Task<BookingHistoryUpdateDTO> UdateBookingStatus(int BookingId, BookingHistory bookingHistory);
        public Task<BookingHistoryUpdateDTO> UpdateBookingMethod(int BookingId, BookingHistory bookingHistory);
        public Task<BookingHistoryUpdateDTO> UpdateCheckInOutStatus(int BookingId, BookingHistory bookingHistory);
        public Task<BookingHistoryUpdateDTO> UpdateBookingHistoryPaymentStatus(int BookingId, BookingHistory bookingHistory);
    }
}

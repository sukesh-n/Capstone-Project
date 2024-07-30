using HotelBookingApp.Models.Payment;

namespace HotelBookingApp.Interface.IRepository.Payments
{
    public interface IBookingPaymentRepository
    {
        public Task<BookingPayment?> AddBooking(BookingPayment bookingPayment);
        public Task<BookingPayment?> GetBookingPaymentById(int bookingPaymentId);
        public Task<BookingPayment> GetBookingByBookingId(int bookingId);
        public Task<IEnumerable<BookingPayment>> GetBookingPayments();
        public Task<BookingPayment?> UpdateBookingPaymentStatus(BookingPayment bookingPayment);

    }
}

using HotelBookingApp.Context;
using HotelBookingApp.Exceptions;
using HotelBookingApp.Interface.IRepository.Payments;
using HotelBookingApp.Models.Payment;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Repositories.PaymentsRepository
{
    public class BookingPaymentRepository : IBookingPaymentRepository
    {
        public HotelBookingDbContext _context;

        public BookingPaymentRepository(HotelBookingDbContext context)
        {
            _context = context;
        }

        public async Task<BookingPayment?> AddBooking(BookingPayment bookingPayment)
        {
            try
            {
                var AddBooking = await _context.BookingPayments.AddAsync(bookingPayment);
                await _context.SaveChangesAsync();
                if (AddBooking.Entity == null)
                {
                    throw new ErrorInConnectingRepositoryException("Error in connecting to the repository");
                }
                return AddBooking.Entity;
            }
            catch (Exception ex)
            {
                throw new ErrorInConnectingRepositoryException("Error in connecting to the repository", ex);
            }
        }

        public async Task<BookingPayment> GetBookingByBookingId(int bookingId)
        {
            try
            {
                var getBooking = await _context.BookingPayments.Where(x=>x.BookingId==bookingId).FirstOrDefaultAsync();
                if (getBooking == null)
                {
                    throw new ErrorInConnectingRepositoryException("Error in connecting to the repository");
                }
                return getBooking;
            }
            catch (Exception ex)
            {
                throw new ErrorInConnectingRepositoryException("Error in connecting to the repository", ex);
            }
        }

        public async Task<BookingPayment?> GetBookingPaymentById(int bookingPaymentId)
        {
            try
            {
                var getBookingPayment = await _context.BookingPayments.FirstOrDefaultAsync(x => x.BookingPaymentId == bookingPaymentId);
                if (getBookingPayment == null)
                {
                    throw new ErrorInConnectingRepositoryException("Error in connecting to the repository");
                }
                return getBookingPayment;
            }
            catch (Exception ex)
            {
                throw new ErrorInConnectingRepositoryException("Error in connecting to the repository", ex);
            }
        }

        public async Task<IEnumerable<BookingPayment>> GetBookingPayments()
        {
            try
            {
                var getBookingPayments = await _context.BookingPayments.ToListAsync();   
                if (getBookingPayments == null)
                {
                    throw new EmptyDataException("Error in connecting to the repository");
                }
                return getBookingPayments;
            }
            catch (Exception ex)
            {
                throw new ErrorInConnectingRepositoryException("Error in connecting to the repository", ex);
            }
        }

        public async Task<BookingPayment?> UpdateBookingPaymentStatus(BookingPayment bookingPayment)
        {
            try
            {
                var existingBookingPayment = await _context.BookingPayments
                    .FirstOrDefaultAsync(x => x.BookingPaymentId == bookingPayment.BookingPaymentId);

                if (existingBookingPayment == null)
                {
                    throw new ErrorInConnectingRepositoryException("BookingPayment not found in the repository.");
                }

                _context.Entry(existingBookingPayment).CurrentValues.SetValues(bookingPayment);

                await _context.SaveChangesAsync();

                return existingBookingPayment;
            }
            catch (Exception ex)
            {
                throw new ErrorInConnectingRepositoryException("An error occurred while updating the booking payment status.", ex);
            }
        }

    }
}

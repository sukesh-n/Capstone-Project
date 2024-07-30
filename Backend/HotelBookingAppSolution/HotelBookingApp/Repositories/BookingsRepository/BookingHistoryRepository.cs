using HotelBookingApp.Context;
using HotelBookingApp.Exceptions;
using HotelBookingApp.Interface.IRepository.IBookings;
using HotelBookingApp.Models.Booking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingApp.Repositories.BookingsRepository
{
    public class BookingHistoryRepository : IBookingHistoryRepository
    {
        private readonly HotelBookingDbContext _context;

        public BookingHistoryRepository(HotelBookingDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<BookingHistory> AddNewBookingAsync(BookingHistory entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BookingHistory>> GetAllBookingsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BookingHistory>> GetBookingByGuestId(int guestId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BookingHistory>> GetBookingByHotelBranchId(int hotelBranchId)
        {
            throw new NotImplementedException();
        }

        public Task<BookingHistory> GetBookingById(int Bookingid)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HardDeleteBookingAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BookingHistory> UdateBookingStatus(int BookingId, BookingHistory bookingHistory)
        {
            throw new NotImplementedException();
        }

        public Task<BookingHistory> UpdateBookingHistoryPaymentStatus(int BookingId, BookingHistory bookingHistory)
        {
            throw new NotImplementedException();
        }

        public Task<BookingHistory> UpdateBookingMethod(int BookingId, BookingHistory bookingHistory)
        {
            throw new NotImplementedException();
        }

        public Task<BookingHistory> UpdateCheckInOutStatus(int BookingId, BookingHistory bookingHistory)
        {
            throw new NotImplementedException();
        }
    }
}

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

        public Task<(int NoOfDaysAvailable, DateTime LongestWindowStartDate, DateTime LongestWindowEndDate)> CheckDateAvailability(DateTime CheckInDate, DateTime CheckOutDate, int HotelBranchId)
        {
            try
            {
                int NoOfDaysAvailable = 0;
                DateTime LongestWindowStartDate = DateTime.MinValue;
                DateTime LongestWindowEndDate = DateTime.MinValue;

                var bookingHistory = _context.BookingHistories
                                       .Where(b => b.HotelBranchId == HotelBranchId && b.CheckOutDate > DateTime.Now)
                                        .ToList();
                if(bookingHistory.Count==0)
                {
                    NoOfDaysAvailable = (CheckOutDate-CheckOutDate).Days;
                    LongestWindowStartDate = CheckInDate;
                    LongestWindowEndDate = CheckOutDate;
                    return Task.FromResult((NoOfDaysAvailable, LongestWindowStartDate, LongestWindowEndDate));
                }
                foreach (var booking in bookingHistory)
                {
                    if (booking.CheckInDate >= CheckInDate && booking.CheckOutDate <= CheckOutDate)
                    {
                        NoOfDaysAvailable = 0;
                        break;
                    }
                    else if (booking.CheckInDate >= CheckInDate && booking.CheckInDate <= CheckOutDate)
                    {
                        NoOfDaysAvailable = (booking.CheckInDate - CheckOutDate).Days;
                        if (NoOfDaysAvailable > 0)
                        {
                            if (NoOfDaysAvailable > (LongestWindowEndDate - LongestWindowStartDate).Days)
                            {
                                LongestWindowStartDate = CheckInDate;
                                LongestWindowEndDate = booking.CheckInDate;
                            }
                        }
                    }
                    else if (booking.CheckOutDate >= CheckInDate && booking.CheckOutDate <= CheckOutDate)
                    {
                        NoOfDaysAvailable = (CheckInDate - booking.CheckOutDate).Days;
                        if (NoOfDaysAvailable > 0)
                        {
                            if (NoOfDaysAvailable > (LongestWindowEndDate - LongestWindowStartDate).Days)
                            {
                                LongestWindowStartDate = booking.CheckOutDate;
                                LongestWindowEndDate = CheckOutDate;
                            }
                        }
                    }
                    else if (booking.CheckInDate <= CheckInDate && booking.CheckOutDate >= CheckOutDate)
                    {
                        NoOfDaysAvailable = 0;
                        break;
                    }
                    else
                    {
                        NoOfDaysAvailable = (CheckInDate - CheckOutDate).Days;
                        if (NoOfDaysAvailable > 0)
                        {
                            if (NoOfDaysAvailable > (LongestWindowEndDate - LongestWindowStartDate).Days)
                            {
                                LongestWindowStartDate = CheckInDate;
                                LongestWindowEndDate = CheckOutDate;
                            }
                        }
                    }
                    if(LongestWindowStartDate==CheckInDate && LongestWindowEndDate==CheckOutDate)
                    {
                        NoOfDaysAvailable = (CheckInDate - CheckOutDate).Days;
                    }
                }
                return Task.FromResult((NoOfDaysAvailable, LongestWindowStartDate, LongestWindowEndDate));
            }
            catch (Exception ex)
            {
                throw new ErrorInConnectingRepositoryException(ex.Message);
            }
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

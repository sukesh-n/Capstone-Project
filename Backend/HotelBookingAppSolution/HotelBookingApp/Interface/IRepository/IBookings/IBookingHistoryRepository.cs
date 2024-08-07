﻿using HotelBookingApp.DTO.BookingDTO;
using HotelBookingApp.Models.Booking;

namespace HotelBookingApp.Interface.IRepository.IBookings
{
    public interface IBookingHistoryRepository
    {
        public Task<BookingHistory> AddNewBookingAsync(BookingHistory entity);
        public Task<bool> HardDeleteBookingAsync(int id);
        public Task<IEnumerable<BookingHistory>> GetAllBookingsAsync();
        public Task<BookingHistory> GetBookingById(int Bookingid);
        public Task<IEnumerable<BookingHistory>> GetBookingByHotelBranchId(int hotelBranchId);
        public Task<IEnumerable<BookingHistory>> GetBookingByGuestId(int guestId);
        public Task<BookingHistory> UdateBookingStatus(int BookingId,BookingHistory bookingHistory);
        public Task<BookingHistory> UpdateBookingMethod(int BookingId,BookingHistory bookingHistory);
        public Task<BookingHistory> UpdateCheckInOutStatus(int BookingId,BookingHistory bookingHistory);
        public Task<BookingHistory> UpdateBookingHistoryPaymentStatus(int BookingId,BookingHistory bookingHistory);

        public Task<(int NoOfDaysAvailable,DateTime LongestWindowStartDate,DateTime LongestWindowEndDate)> CheckDateAvailability(DateTime CheckInDate,DateTime CheckOutDate,int HotelBranchId);
        public Task<(int NoOfDaysAvailable,DateTime LongestWindowStartDate,DateTime LongestWindowEndDate,int NoOfRoomsAvailable)> CheckDateAvailabilityForRoomType(DateTime CheckInDate,DateTime CheckOutDate,int HotelBranchId,int RoomTypeId,int NoOfRooms);
    }
}

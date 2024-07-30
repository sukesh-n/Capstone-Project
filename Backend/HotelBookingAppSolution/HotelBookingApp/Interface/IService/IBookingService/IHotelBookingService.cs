using HotelBookingApp.DTO.BookingDTO;

namespace HotelBookingApp.Interface.IService.IBookingService
{
    public interface IHotelBookingService
    {
        public Task<HotelBookingDTO> AddNewHotelBooking(BookingBranchDTO bookingBranchDTO);
        public Task<HotelBookingDTO> AddNewHotelBookingWithConnection(BookingBranchDTO bookingBranch);
        public Task<HotelBookingDTO> UpdateHotelBooking(BookingBranchDTO bookingBranchDTO);
        public Task<HotelBookingDTO> CancelHotelBooking(int hotelBookingId);
        public Task<HotelBookingDTO> GetHotelBooking(int hotelBookingId);
        public Task<IEnumerable<HotelBookingDTO>> GetAllHotelBookingUnderHotel();
    }
}

using HotelBookingApp.DTO.BookingDTO;

namespace HotelBookingApp.Interface.IService.IBookingService
{
    public interface IHotelBookingService
    {
        public Task<HotelBookingDTO> AddNewHotelBooking(HotelBookingDTO hotelBookingDTO);
        public Task<HotelBookingDTO> UpdateHotelBooking(HotelBookingDTO hotelBookingDTO);
        public Task<HotelBookingDTO> CancelHotelBooking(int hotelBookingId);
        public Task<HotelBookingDTO> GetHotelBooking(int hotelBookingId);
        public Task<IEnumerable<HotelBookingDTO>> GetAllHotelBookingUnderHotel();
    }
}

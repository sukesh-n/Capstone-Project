using HotelBookingApp.DTO.BookingDTO;
using HotelBookingApp.Interface.IService.IBookingService;

namespace HotelBookingApp.Services.BookingService
{
    public class HotelBookingService : IHotelBookingService
    {
        public Task<HotelBookingDTO> AddNewHotelBooking(HotelBookingDTO hotelBookingDTO)
        {
            throw new NotImplementedException();
        }

        public Task<HotelBookingDTO> CancelHotelBooking(int hotelBookingId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<HotelBookingDTO>> GetAllHotelBookingUnderHotel()
        {
            throw new NotImplementedException();
        }

        public Task<HotelBookingDTO> GetHotelBooking(int hotelBookingId)
        {
            throw new NotImplementedException();
        }

        public Task<HotelBookingDTO> UpdateHotelBooking(HotelBookingDTO hotelBookingDTO)
        {
            throw new NotImplementedException();
        }
    }
}

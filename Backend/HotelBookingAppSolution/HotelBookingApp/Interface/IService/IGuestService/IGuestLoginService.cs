using HotelBookingApp.DTO.GuestDTO;

namespace HotelBookingApp.Interface.IService.IGuestService
{
    public interface IGuestLoginService
    {
        public Task<GuestLoginDTO> GuestLogin(GuestLoginDTO guestLoginDTO);
    }
}

using HotelBookingApp.DTO.GuestDTO;

namespace HotelBookingApp.Interface.IService.IGuestService
{
    public interface IGuestAccountService
    {
        Task<GuestAccountDTO> AddNewGuest(GuestAccountDTO guestAccountDTO);
        Task<GuestAccountDTO> UpdateGuest(GuestAccountDTO guestAccountDTO);
        Task<GuestAccountDTO> DeleteGuest(int guestId);
        Task<GuestDTO> GetGuest(int guestId);
        Task<IEnumerable<GuestDTO>> GetAllGuests();
        Task<GuestAccountDTO> UpdateGuestSecurity(string email, string password);

    }
}

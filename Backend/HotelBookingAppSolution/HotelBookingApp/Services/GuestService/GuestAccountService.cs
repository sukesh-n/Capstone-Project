using HotelBookingApp.DTO.GuestDTO;
using HotelBookingApp.Interface.IService.IGuestService;

namespace HotelBookingApp.Services.GuestService
{
    public class GuestAccountService : IGuestAccountService
    {
        public Task<GuestAccountDTO> AddNewGuest(GuestAccountDTO guestAccountDTO)
        {
            throw new NotImplementedException();
        }

        public Task<GuestAccountDTO> DeleteGuest(int guestId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GuestDTO>> GetAllGuests()
        {
            throw new NotImplementedException();
        }

        public Task<GuestDTO> GetGuest(int guestId)
        {
            throw new NotImplementedException();
        }

        public Task<GuestAccountDTO> UpdateGuest(GuestAccountDTO guestAccountDTO)
        {
            throw new NotImplementedException();
        }
    }
}

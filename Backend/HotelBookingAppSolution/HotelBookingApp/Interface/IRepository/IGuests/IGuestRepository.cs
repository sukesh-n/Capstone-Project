using HotelBookingApp.Models.Guests;

namespace HotelBookingApp.Interface.IRepository.IGuests
{
    public interface IGuestRepository : IMasterRepository<int,Guest>
    {
        public Task<Guest?> GetGuestByEmail(string email);
    }
}

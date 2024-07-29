using HotelBookingApp.Models.Hotels.HotelGroups;

namespace HotelBookingApp.Interface.IRepository.IHotels.IHotelGroups
{
    public interface IHotelGroupRepository : IMasterRepository<int,HotelGroup>
    {
        public Task<HotelGroup?> GetHotelGroupByEmail(string Email);
    }
}

using HotelBookingApp.Models.Hotels;
using HotelBookingApp.Models.Hotels.HotelBranches;

namespace HotelBookingApp.Interface.IRepository.IHotels
{
    public interface IHotelDemographicsRepository : IMasterRepository<int,HotelDemographics>
    {
        public Task<IEnumerable<HotelDemographics>?> GetHotelBranchByLocation(string? State, string? District);
    }
}

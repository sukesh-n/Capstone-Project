using HotelBookingApp.Models.Hotels.HotelBranches;

namespace HotelBookingApp.Interface.IRepository.IHotels.IHotelBranches
{
    public interface IHotelBranchRepository : IMasterRepository<int,HotelBranch>
    {
        public Task<HotelBranch?> GetHotelBranchByEmail(string Email);
        public Task<List<HotelBranch>?> GetHotelBranchesByGroupId(int HotelGroupId);
    }
}

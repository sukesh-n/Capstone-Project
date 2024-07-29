using HotelBookingApp.Models.Hotels.HotelBranches;

namespace HotelBookingApp.Interface.IRepository.IHotels.IHotelBranches
{
    public interface IHotelBranchSecurityRepository : IMasterRepository<int,HotelBranchSecurity>
    {
        public Task<HotelBranchSecurity> GetSecurityByBranchId(int BranchId);
    }
}

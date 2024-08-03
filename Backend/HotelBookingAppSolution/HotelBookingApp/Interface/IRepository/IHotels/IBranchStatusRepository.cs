using HotelBookingApp.Models.Hotels;

namespace HotelBookingApp.Interface.IRepository.IHotels
{
    public interface IBranchStatusRepository 
    {
        public Task<BranchStatus> AddNewBranchStatus(BranchStatus branchStatus);
        public Task<BranchStatus?> GetBranchStatus(int BranchId);
        public Task<BranchStatus> UpdateBranchStatus(BranchStatus branchStatus);
    }
}

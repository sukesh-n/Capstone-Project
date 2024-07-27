using HotelBookingApp.DTO.HotelBranchDTO;

namespace HotelBookingApp.Interface.IService.IHotelBranchService
{
    public interface IBranchBookingManagementService
    {
        public Task<BranchBookingDTO> AddNewBranchBooking(BranchBookingDTO branchBookingDTO);
        public Task<BranchBookingDTO> UpdateBranchBooking(BranchBookingDTO branchBookingDTO);
        public Task<BranchBookingDTO> DeleteBranchBooking(int branchBookingId);
        public Task<BranchBookingDTO> GetBranchBooking(int branchBookingId);
        public Task<IEnumerable<BranchBookingDTO>> GetAllBranchBookingUnderBranch();
    }
}

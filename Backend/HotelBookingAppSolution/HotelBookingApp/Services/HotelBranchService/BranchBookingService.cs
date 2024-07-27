using HotelBookingApp.DTO.HotelBranchDTO;
using HotelBookingApp.Interface.IService.IHotelBranchService;

namespace HotelBookingApp.Services.HotelBranchService
{
    public class BranchBookingService : IBranchBookingManagementService
    {
        public Task<BranchBookingDTO> AddNewBranchBooking(BranchBookingDTO branchBookingDTO)
        {
            throw new NotImplementedException();
        }

        public Task<BranchBookingDTO> DeleteBranchBooking(int branchBookingId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BranchBookingDTO>> GetAllBranchBookingUnderBranch()
        {
            throw new NotImplementedException();
        }

        public Task<BranchBookingDTO> GetBranchBooking(int branchBookingId)
        {
            throw new NotImplementedException();
        }

        public Task<BranchBookingDTO> UpdateBranchBooking(BranchBookingDTO branchBookingDTO)
        {
            throw new NotImplementedException();
        }
    }
}

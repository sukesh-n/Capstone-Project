using HotelBookingApp.DTO.HotelGroupDTO;

namespace HotelBookingApp.Interface.IService.IHotelGroupService
{
    public interface IBranchAccountService
    {
        public Task<BranchAccountDTO> CreateBranchAccount(BranchAccountDTO branchAccountDTO);
        public Task<BranchAccountDTO> GetBranchAccount(int branchId);
        public Task<BranchAccountDTO> UpdateBranchAccount(BranchAccountDTO branchAccountDTO);
        public Task<BranchAccountDTO> DeleteBranchAccount(int BranchId);   
        public Task<IEnumerable<BranchAccountDTO>> GetAllBranches();
    }
}

using HotelBookingApp.DTO.HotelGroupDTO;

namespace HotelBookingApp.Interface.IService.IHotelGroupService
{
    public interface IBranchAccountService
    {
        public Task<BranchAccountDTO> CreateBranchAccount(BranchAccountDTO branchAccountDTO);
        public Task<BranchAccountDTO> GetBranchAccount(int branchId);
        public Task<BranchAccountDTO> UpdateBranchAccount(BranchAccountDTO branchAccountDTO);
        public Task<BranchAccountDTO> UpdateBranchAccountSecurity(string BranchMail,string Password);
        public Task<bool> DeleteBranchAccount(int BranchId);
        public Task<bool> DeleteBranchAccountByGroupId(int Groupid);
        public Task<IEnumerable<BranchAccountDTO>> GetAllBranches();
    }
}

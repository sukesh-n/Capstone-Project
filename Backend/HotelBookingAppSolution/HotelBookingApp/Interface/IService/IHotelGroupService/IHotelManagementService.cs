using HotelBookingApp.DTO.HotelGroupDTO;

namespace HotelBookingApp.Interface.IService.IHotelGroupService
{
    public interface IHotelManagementService
    {
        public Task<HotelBranchDTO> AddNewHotelBranch(HotelBranchDTO HotelBranchDTO);
        public Task<HotelBranchDTO> UpdateHotelBranch(HotelBranchDTO HotelBranchDTO);
        public Task<HotelBranchDTO> DeleteHotelBranch(int hotelBranchId);
        public Task<HotelBranchDTO> GetHotelBranch(int hotelBranchId);
        public Task<IEnumerable<HotelBranchDTO>> GetAllHotelBranchUnderGroup();

    }
}

using HotelBookingApp.DTO.HotelBranchDTO;
using HotelBookingApp.DTO.HotelGroupDTO;
using HotelBookingApp.Models.Hotels;

namespace HotelBookingApp.Interface.IService.IHotelGroupService
{
    public interface IHotelManagementService
    {
        public Task<HotelBranchDTO> AddNewHotelBranch(HotelBranchDTO HotelBranchDTO);
        public Task<HotelBranchDTO> UpdateHotelBranch(HotelBranchDTO HotelBranchDTO);
        public Task<HotelBranchDTO> DeleteHotelBranch(int hotelBranchId);
        public Task<HotelBranchDTO> GetHotelBranch(int hotelBranchId);
        public Task<IEnumerable<HotelBranchDTO>> GetAllHotelBranchUnderGroup();
        public Task<IEnumerable<BranchRoomDetailsDTO>> GetAllBranchRooms(int BranchId);
        public Task<HotelBranchRoomDTO> AddBranchRoom(HotelBranchRoomDTO hotelBranchRoomDTO);
        public Task<HotelBranchRoomDTO> UpdateBranchRoom(HotelBranchRoomDTO hotelBranchRoomDTO);
        public Task<bool> DeleteRoomType(int RoomTypeId);
        public Task<BranchStatus> UpdateStatus(int BranchId, BranchStatus branchStatus);
        public Task<BranchStatus> GetBranchStatus(int BranchId);

    }
}

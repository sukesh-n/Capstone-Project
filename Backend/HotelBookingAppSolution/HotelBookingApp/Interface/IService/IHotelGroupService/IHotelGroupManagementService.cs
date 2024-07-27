using HotelBookingApp.DTO.HotelGroupDTO;

namespace HotelBookingApp.Interface.IService.IHotelGroupService
{
    public interface IHotelGroupManagementService
    {
        public Task<HotelGroupsDTO> AddNewHotelGroup(HotelGroupsDTO addNewHotelGroupDTO);
        public Task<HotelGroupsDTO> UpdateHotelGroup(HotelGroupsDTO HotelGroupDTO);
        public Task<HotelGroupsDTO> DeleteHotelGroup(int hotelGroupId);
        public Task<HotelGroupsDTO> GetHotelGroup(int hotelGroupId);
        public Task<IEnumerable<HotelGroupsDTO>> GetAllHotelGroup();
    }
}

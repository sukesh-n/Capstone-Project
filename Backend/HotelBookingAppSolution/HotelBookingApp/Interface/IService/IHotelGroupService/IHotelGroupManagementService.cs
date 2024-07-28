using HotelBookingApp.DTO.HotelGroupDTO;

namespace HotelBookingApp.Interface.IService.IHotelGroupService
{
    public interface IHotelGroupManagementService
    {
        public Task<HotelGroupsDTO> AddHotelGroupDetails(HotelGroupsDTO addNewHotelGroupDTO);
        public Task<HotelGroupsDTO> UpdateHotelGroupDetails(HotelGroupsDTO HotelGroupDTO);
        public Task<HotelGroupsDTO> DeleteHotelGroupDetails(int hotelGroupId);
        public Task<HotelGroupsDTO> GetHotelGroupDetails(int hotelGroupId);
        public Task<IEnumerable<HotelGroupsDTO>> GetAllHotelGroupDetails();
    }
}

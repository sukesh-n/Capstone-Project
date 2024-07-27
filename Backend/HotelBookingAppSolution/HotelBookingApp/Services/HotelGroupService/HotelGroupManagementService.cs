using HotelBookingApp.DTO.HotelGroupDTO;
using HotelBookingApp.Interface.IService.IHotelGroupService;

namespace HotelBookingApp.Services.HotelGroupService
{
    public class HotelGroupManagementService : IHotelGroupManagementService
    {
        public Task<HotelGroupsDTO> AddNewHotelGroup(HotelGroupsDTO addNewHotelGroupDTO)
        {
            throw new NotImplementedException();
        }

        public Task<HotelGroupsDTO> DeleteHotelGroup(int hotelGroupId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<HotelGroupsDTO>> GetAllHotelGroup()
        {
            throw new NotImplementedException();
        }

        public Task<HotelGroupsDTO> GetHotelGroup(int hotelGroupId)
        {
            throw new NotImplementedException();
        }

        public Task<HotelGroupsDTO> UpdateHotelGroup(HotelGroupsDTO HotelGroupDTO)
        {
            throw new NotImplementedException();
        }
    }
}

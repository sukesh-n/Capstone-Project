using HotelBookingApp.DTO.HotelGroupDTO;
using HotelBookingApp.Interface.IService.IHotelGroupService;

namespace HotelBookingApp.Services.HotelGroupService
{
    public class HotelGroupManagementService : IHotelGroupManagementService
    {
        public Task<HotelGroupsDTO> AddHotelGroupDetails(HotelGroupsDTO addNewHotelGroupDTO)
        {
            throw new NotImplementedException();
        }

        public Task<HotelGroupsDTO> DeleteHotelGroupDetails(int hotelGroupId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<HotelGroupsDTO>> GetAllHotelGroupDetails()
        {
            throw new NotImplementedException();
        }

        public Task<HotelGroupsDTO> GetHotelGroupDetails(int hotelGroupId)
        {
            throw new NotImplementedException();
        }

        public Task<HotelGroupsDTO> UpdateHotelGroupDetails(HotelGroupsDTO HotelGroupDTO)
        {
            throw new NotImplementedException();
        }
    }
}

using HotelBookingApp.DTO.HotelGroupDTO;
using HotelBookingApp.Interface.IService.IHotelGroupService;

namespace HotelBookingApp.Services.HotelGroupService
{
    public class HotelManagementService : IHotelManagementService
    {
        public Task<HotelBranchDTO> AddNewHotelBranch(HotelBranchDTO addNewHotelBranchDTO)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<HotelBranchDTO> DeleteHotelBranch(int hotelBranchId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<HotelBranchDTO>> GetAllHotelBranchUnderGroup()
        {
            throw new NotImplementedException();
        }

        public Task<HotelBranchDTO> GetHotelBranch(int hotelBranchId)
        {
            throw new NotImplementedException();
        }

        public Task<HotelBranchDTO> UpdateHotelBranch(HotelBranchDTO HotelBranchDTO)
        {
            throw new NotImplementedException();
        }
    }
}

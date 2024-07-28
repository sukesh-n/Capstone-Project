using HotelBookingApp.DTO.HotelGroupDTO;
using HotelBookingApp.Interface.IService.IHotelGroupService;

namespace HotelBookingApp.Services.HotelGroupService
{
    public class GroupAccountService : IGroupAccountService
    {
        public Task<GroupAccountDTO> CreateGroupAccount(GroupAccountDTO groupAccountDTO)
        {
            throw new NotImplementedException();
        }

        public Task<GroupAccountDTO> DeleteGroupAccount(int GroupId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GroupAccountDTO>> GetAllGroups()
        {
            throw new NotImplementedException();
        }

        public Task<GroupAccountDTO> GetGroupAccount(int GroupId)
        {
            throw new NotImplementedException();
        }

        public Task<GroupAccountDTO> UpdateGroupAccount(GroupAccountDTO groupAccountDTO)
        {
            throw new NotImplementedException();
        }
    }
}

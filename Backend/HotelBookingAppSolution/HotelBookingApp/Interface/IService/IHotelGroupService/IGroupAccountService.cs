using HotelBookingApp.DTO.HotelGroupDTO;

namespace HotelBookingApp.Interface.IService.IHotelGroupService
{
    public interface IGroupAccountService
    {
        public Task<GroupAccountDTO> CreateGroupAccount(GroupAccountDTO groupAccountDTO);
        public Task<GroupAccountDTO> GetGroupAccount(int GroupId);
        public Task<GroupAccountDTO> UpdateGroupAccount(GroupAccountDTO groupAccountDTO);
        public Task<GroupAccountDTO> DeleteGroupAccount(int GroupId);
        public Task<IEnumerable<GroupAccountDTO>> GetAllGroups();
        
    }
}
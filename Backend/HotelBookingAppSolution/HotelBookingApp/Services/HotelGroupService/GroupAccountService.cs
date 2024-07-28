using HotelBookingApp.DTO.HotelGroupDTO;
using HotelBookingApp.Exceptions;
using HotelBookingApp.Interface.IRepository.IHotels.IHotelGroups;
using HotelBookingApp.Interface.IService.IHotelGroupService;
using HotelBookingApp.Models.Hotels.HotelGroups;
using HotelBookingApp.Services.Hashing;
using System.ComponentModel;

namespace HotelBookingApp.Services.HotelGroupService
{
    public class GroupAccountService : IGroupAccountService
    {
        private readonly IHotelGroupRepository _hotelGroupRepository;
        private readonly IHotelGroupSecurityRepository _hotelGroupSecurityRepository;
        private readonly Password _password;
        public GroupAccountService(IHotelGroupRepository hotelGroupRepository, Password password, IHotelGroupSecurityRepository hotelGroupSecurityRepository)
        {
            _hotelGroupRepository = hotelGroupRepository;
            _password = password;
            _hotelGroupSecurityRepository = hotelGroupSecurityRepository;
        }

        public async Task<GroupAccountDTO> CreateGroupAccount(GroupAccountDTO groupAccountDTO)
        {
            if (groupAccountDTO.HotelGroup == null)
            {
                throw new ArgumentNullException(nameof(groupAccountDTO.HotelGroup), "HotelGroup cannot be null");
            }
            try
            {
                var accountCreation = await _hotelGroupRepository.AddAsync(enitity: groupAccountDTO.HotelGroup);
                if(accountCreation == null)
                {
                    throw new ErrorInService("Error: Group Account not created");
                }
                var SecurityDTO = new HotelGroupSecurity();
                {
                    var PasswordHashSet = _password.PasswordHashing(groupAccountDTO.Password);
                    SecurityDTO.HotelGroupPasswordHashKey = PasswordHashSet.PasswordHashKey_;
                    SecurityDTO.HotelGroupPassword= PasswordHashSet.PasswordByte;
                }
                var SecurityCreation = await _hotelGroupSecurityRepository.AddAsync(SecurityDTO);
                if(SecurityCreation == null)
                {
                    var DeleteAccount = _hotelGroupRepository.DeleteAsync(accountCreation.HotelGroupId);
                    throw new ErrorInService("Error: Group Account Security not created");
                }
                return new GroupAccountDTO
                {
                    HotelGroup = accountCreation,
                    Password = groupAccountDTO.Password
                };
            }
            catch (Exception ex)
            {
                throw new ErrorInService($"Error: {ex.Message}");
            }
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

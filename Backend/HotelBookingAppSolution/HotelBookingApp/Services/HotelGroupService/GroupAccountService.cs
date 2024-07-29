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
        private readonly IBranchAccountService _branchAccountService;
        private readonly Password _password;
        public GroupAccountService(IHotelGroupRepository hotelGroupRepository, Password password, IHotelGroupSecurityRepository hotelGroupSecurityRepository, IBranchAccountService branchAccountService)
        {
            _hotelGroupRepository = hotelGroupRepository;
            _password = password;
            _hotelGroupSecurityRepository = hotelGroupSecurityRepository;
            _branchAccountService = branchAccountService;
        }

        public async Task<GroupAccountDTO> CreateGroupAccount(GroupAccountDTO groupAccountDTO)
        {
            if (groupAccountDTO.HotelGroup == null)
            {
                throw new ArgumentNullException(nameof(groupAccountDTO.HotelGroup), "HotelGroup cannot be null");
            }
            try
            {
                var checkDuplicate = await _hotelGroupRepository.GetHotelGroupByEmail(groupAccountDTO.HotelGroup.HotelGroupEmail);
                if (checkDuplicate != null)
                {
                    var checkDuplicateSecurity = await _hotelGroupSecurityRepository.GetByIdAsync(checkDuplicate.HotelGroupId);
                    if (checkDuplicateSecurity.HotelGroupId != -1)
                    {
                        throw new ErrorInServiceException("Error: Group Account already exists");
                    }
                    else
                    {
                        var UpdateSecurityDTO = new HotelGroupSecurity();
                        {
                            var PasswordHashSet = _password.PasswordHashing(groupAccountDTO.Password);
                            UpdateSecurityDTO.HotelGroupId = checkDuplicate.HotelGroupId;
                            UpdateSecurityDTO.HotelGroupPasswordHashKey = PasswordHashSet.PasswordHashKey_;
                            UpdateSecurityDTO.HotelGroupPassword = PasswordHashSet.PasswordByte;
                        }
                        var UpdateSecurityCreation = await _hotelGroupSecurityRepository.AddAsync(UpdateSecurityDTO);
                        if (UpdateSecurityCreation == null)
                        {
                            throw new ErrorInServiceException("Error: Group Account Security not created");
                        }
                        return new GroupAccountDTO
                        {
                            HotelGroup = checkDuplicate,
                            Password = groupAccountDTO.Password
                        };
                    }
                }
                var accountCreation = await _hotelGroupRepository.AddAsync(enitity: groupAccountDTO.HotelGroup);
                if(accountCreation == null)
                {
                    throw new ErrorInServiceException("Error: Group Account not created");
                }
                var SecurityDTO = new HotelGroupSecurity();
                {
                    var PasswordHashSet = _password.PasswordHashing(groupAccountDTO.Password);
                    SecurityDTO.HotelGroupId = accountCreation.HotelGroupId;
                    SecurityDTO.HotelGroupPasswordHashKey = PasswordHashSet.PasswordHashKey_;
                    SecurityDTO.HotelGroupPassword= PasswordHashSet.PasswordByte;
                }
                var SecurityCreation = await _hotelGroupSecurityRepository.AddAsync(SecurityDTO);
                if(SecurityCreation == null)
                {
                    var DeleteAccount = _hotelGroupRepository.DeleteAsync(accountCreation.HotelGroupId);
                    throw new ErrorInServiceException("Error: Group Account Security not created");
                }
                return new GroupAccountDTO
                {
                    HotelGroup = accountCreation,
                    Password = groupAccountDTO.Password
                };
            }
            catch (Exception ex)
            {
                throw new ErrorInServiceException($"Error: {ex.Message}");
            }
        }

        public async Task<bool> DeleteGroupAccount(int GroupId)
        {
            try
            {
                var GetGroupBranches = await _branchAccountService.DeleteBranchAccountByGroupId(GroupId);
                var deletegroup = await _hotelGroupRepository.DeleteAsync(GroupId);
                if (deletegroup == false)
                {
                    throw new ErrorInServiceException("Error: Group Account not deleted");
                }
                return deletegroup;
            }
            catch (Exception ex)
            {
                throw new ErrorInServiceException($"Error: {ex.Message}");
            }
        }

        public Task<IEnumerable<GroupAccountDTO>> GetAllGroups()
        {
            throw new NotImplementedException();
        }

        public Task<GroupAccountDTO> GetGroupAccount(int GroupId)
        {
            throw new NotImplementedException();
        }

        public async Task<GroupAccountDTO> UpdateGroupAccountSecurity(GroupAccountDTO groupAccountDTO)
        {
            if (groupAccountDTO.HotelGroup == null)
            {
                throw new ArgumentNullException(nameof(groupAccountDTO.HotelGroup), "HotelGroup cannot be null");
            }
            try
            {
                var checkGroup = await _hotelGroupRepository.GetHotelGroupByEmail(groupAccountDTO.HotelGroup.HotelGroupEmail);
                if (checkGroup == null)
                {
                    throw new ErrorInServiceException("Error: Group Account not found");
                }
                var checkSecurity = await _hotelGroupSecurityRepository.GetByIdAsync(checkGroup.HotelGroupId);
                if (checkSecurity.HotelGroupId == -1)
                {
                    throw new ErrorInServiceException("Error: Group Account Security not found");
                }
                var PasswordHashSet = _password.PasswordHashing(groupAccountDTO.Password);
                checkSecurity.HotelGroupId = checkGroup.HotelGroupId;
                checkSecurity.HotelGroupPasswordHashKey = PasswordHashSet.PasswordHashKey_;
                checkSecurity.HotelGroupPassword = PasswordHashSet.PasswordByte;
                var UpdateSecurity = await _hotelGroupSecurityRepository.UpdateAsync(checkSecurity);
                if (UpdateSecurity == null)
                {
                    throw new ErrorInServiceException("Error: Group Account Security not updated");
                }
                return new GroupAccountDTO
                {
                    HotelGroup = checkGroup,
                    Password = groupAccountDTO.Password
                };
            }
            catch (Exception ex)
            {
                throw new ErrorInServiceException($"Error: {ex.Message}");
            }
        }
    }
}

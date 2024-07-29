using HotelBookingApp.DTO.HotelGroupDTO;
using HotelBookingApp.Exceptions;
using HotelBookingApp.Interface.IRepository.IHotels.IHotelBranches;
using HotelBookingApp.Interface.IRepository.IHotels.IHotelGroups;
using HotelBookingApp.Interface.IService.IHotelGroupService;
using HotelBookingApp.Models.Hotels.HotelBranches;
using HotelBookingApp.Services.Hashing;

namespace HotelBookingApp.Services.HotelGroupService
{
    public class BranchAccountService : IBranchAccountService
    {
        public readonly IHotelBranchRepository _hotelBranchRepository;
        public readonly IHotelBranchSecurityRepository _hotelBranchSecurityRepository;
        public readonly IHotelGroupRepository _hotelGroupRepository;
        public readonly Password _password;

        public BranchAccountService(IHotelBranchRepository hotelBranchRepository, IHotelBranchSecurityRepository hotelBranchSecurityRepository, Password password, IHotelGroupRepository hotelGroupRepository)
        {
            _hotelBranchRepository = hotelBranchRepository;
            _hotelBranchSecurityRepository = hotelBranchSecurityRepository;
            _password = password;
            _hotelGroupRepository = hotelGroupRepository;
        }
        public async Task<BranchAccountDTO> CreateBranchAccount(BranchAccountDTO branchAccountDTO)
        {
            if (branchAccountDTO.Hotel == null)
            {
                throw new ArgumentNullException(nameof(branchAccountDTO.Hotel), "HotelBranch cannot be null");
            }
            try
            {
                var DuplicateBranch = await _hotelBranchRepository.GetHotelBranchByEmail(branchAccountDTO.Hotel.HotelBranchEmail);
                if (DuplicateBranch != null)
                {
                    throw new Exception("Branch already exists");
                }
                var GetGroupDetails = await _hotelGroupRepository.GetByIdAsync(branchAccountDTO.Hotel.HotelGroupId);
                if (GetGroupDetails == null)
                {
                    throw new Exception("Group not found");
                }
                branchAccountDTO.Hotel.HotelGroup = GetGroupDetails;
                var BranchCreation = await _hotelBranchRepository.AddAsync(branchAccountDTO.Hotel);
                if (BranchCreation == null)
                {
                    throw new Exception("Branch not created");
                }
                var SecurityCreation = new HotelBranchSecurity();
                {
                    var PasswordHash = _password.PasswordHashing(branchAccountDTO.Password);
                    SecurityCreation.HotelBranchId = branchAccountDTO.Hotel.HotelBranchId;
                    SecurityCreation.HotelBranchPasswordHashKey = PasswordHash.PasswordHashKey_;
                    SecurityCreation.HotelBranchPassword = PasswordHash.PasswordByte;
                }
                var SecurityCreationResult = await _hotelBranchSecurityRepository.AddAsync(SecurityCreation);
                if (SecurityCreationResult == null)
                {
                    var BranchDelete = await _hotelBranchRepository.DeleteAsync(BranchCreation.HotelBranchId);
                    throw new Exception("Branch Security not created");
                }
                return new BranchAccountDTO
                {
                    Hotel = BranchCreation,
                    Password = branchAccountDTO.Password
                };
            }
            catch (Exception ex)
            {
                throw new ErrorInServiceException("Service Error", ex);
            }
        }

        public async Task<bool> DeleteBranchAccount(int BranchId)
        {
            try
            {
                var DeleteBranch = await _hotelBranchRepository.DeleteAsync(BranchId);
                if (DeleteBranch == false )
                {
                    throw new Exception("Branch not deleted");
                }
                return DeleteBranch;
            }
            catch (Exception ex)
            {
                throw new ErrorInServiceException("Service Error", ex);
            }
        }

        public async Task<bool> DeleteBranchAccountByGroupId(int Groupid)
        {
            try
            {
                var GetAllBranches = await _hotelBranchRepository.GetHotelBranchesByGroupId(Groupid);
                if (GetAllBranches == null)
                {
                    return false;
                }
                foreach (var branch in GetAllBranches)
                {
                    var DeleteBranch = await DeleteBranchAccount(branch.HotelBranchId);
                    if (DeleteBranch == false)
                    {
                        throw new Exception("Branch not deleted");
                    }

                }
                return true;
            }
            catch (Exception ex)
            {
                throw new ErrorInServiceException("Service Error", ex);
            }
        }

        public Task<IEnumerable<BranchAccountDTO>> GetAllBranches()
        {
            throw new NotImplementedException();
        }

        public Task<BranchAccountDTO> GetBranchAccount(int branchId)
        {
            throw new NotImplementedException();
        }

        public Task<BranchAccountDTO> UpdateBranchAccount(BranchAccountDTO branchAccountDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<BranchAccountDTO> UpdateBranchAccountSecurity(string branchMail, string password)
        {
            try
            {
                var account = await _hotelBranchRepository.GetHotelBranchByEmail(branchMail);
                if (account == null)
                {
                    throw new InvalidOperationException("Branch not found");
                }

                var passwordHash = _password.PasswordHashing(password);
                var securityDTO = new HotelBranchSecurity
                {
                    HotelBranchId = account.HotelBranchId,
                    HotelBranchPasswordHashKey = passwordHash.PasswordHashKey_,
                    HotelBranchPassword = passwordHash.PasswordByte
                };

                var existingSecurity = await _hotelBranchSecurityRepository.GetSecurityByBranchId(account.HotelBranchId);
                if (existingSecurity.HotelBranchId != -1)
                {
                    existingSecurity.HotelBranchPasswordHashKey = passwordHash.PasswordHashKey_;
                    existingSecurity.HotelBranchPassword = passwordHash.PasswordByte;
                    await _hotelBranchSecurityRepository.UpdateAsync(existingSecurity);
                }
                else
                {
                    await _hotelBranchSecurityRepository.AddAsync(securityDTO);
                }

                return new BranchAccountDTO
                {
                    Hotel = account,
                    Password = password
                };
            }
            catch (Exception ex)
            {
                throw new ErrorInServiceException("An error occurred while updating the branch account security", ex);
            }
        }


    }
}

using HotelBookingApp.DTO.HotelBranchDTO;
using HotelBookingApp.DTO.HotelGroupDTO;
using HotelBookingApp.Exceptions;
using HotelBookingApp.Interface.IRepository.IHotels.IHotelBranches;
using HotelBookingApp.Interface.IService.IHotelBranchService;
using HotelBookingApp.Interface.IToken;
using HotelBookingApp.Models.Hotels.HotelBranches;
using HotelBookingApp.Models.Hotels.HotelGroups;
using HotelBookingApp.Services.Hashing;

namespace HotelBookingApp.Services.HotelBranchService
{
    public class BranchLoginService : IBranchLoginService
    {
        IHotelBranchRepository _hotelBranchRepository;
        IHotelBranchSecurityRepository _hotelBranchSecurityRepository;
        Password _password;
        ITokenService _tokenService;

        public BranchLoginService(IHotelBranchRepository hotelBranchRepository, IHotelBranchSecurityRepository hotelBranchSecurityRepository, Password password, ITokenService tokenService)
        {
            _hotelBranchRepository = hotelBranchRepository;
            _hotelBranchSecurityRepository = hotelBranchSecurityRepository;
            _password = password;
            _tokenService = tokenService;
        }

        public async Task<BranchLoginReturnDTO> BranchLogin(HotelBranchLoginDTO hotelBranchLoginDTO)
        {
            if (hotelBranchLoginDTO.Email == null || hotelBranchLoginDTO.Password == null)
            {
                throw new ArgumentNullException(nameof(hotelBranchLoginDTO));
            }
            try
            {
                var getBranch = await _hotelBranchRepository.GetHotelBranchByEmail(hotelBranchLoginDTO.Email);
                if (getBranch == null)
                {
                    throw new ErrorInServiceException();
                }
                var getBranchSecurity = await _hotelBranchSecurityRepository.GetByIdAsync(getBranch.HotelBranchId);
                if (getBranchSecurity.HotelBranchPassword == null || getBranchSecurity.HotelBranchPasswordHashKey == null)
                {
                    throw new ErrorInServiceException();
                }
                var IsPassSame = _password.ComparePassword(hotelBranchLoginDTO.Password, getBranchSecurity.HotelBranchPassword, getBranchSecurity.HotelBranchPasswordHashKey);
                if (IsPassSame)
                {
                    return BranchLoginReturn(getBranch);
                }
                else
                {
                    throw new ErrorInServiceException();
                };
            }
            catch (Exception)
            {
                throw new ErrorInServiceException();
            }
        }
        public BranchLoginReturnDTO BranchLoginReturn(HotelBranch user)
        {
            BranchLoginReturnDTO loginReturnDTO = new BranchLoginReturnDTO()
            {
                 BranchEmail = user.HotelBranchEmail,
                BranchId = user.HotelBranchId,
                Role = "HotelBranch",
                Token = _tokenService.GenerateHotelBranchToken(user)
            };
            return loginReturnDTO;
        }
    }
}

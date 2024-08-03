using HotelBookingApp.DTO.HotelGroupDTO;
using HotelBookingApp.Exceptions;
using HotelBookingApp.Interface.IRepository.IHotels.IHotelGroups;
using HotelBookingApp.Interface.IService.IHotelGroupService;
using HotelBookingApp.Interface.IToken;
using HotelBookingApp.Models.Hotels.HotelGroups;
using HotelBookingApp.Services.Hashing;

namespace HotelBookingApp.Services.HotelGroupService
{
    public class GroupLoginService : IGroupLoginService
    {
        IHotelGroupRepository _hotelGroupRepository;
        IHotelGroupSecurityRepository _hotelGroupSecurityRepository;
        Password _password;
        ITokenService _tokenService;
        public GroupLoginService(IHotelGroupRepository hotelGroupRepository, IHotelGroupSecurityRepository hotelGroupSecurityRepository, Password password, ITokenService tokenService)
        {
            _hotelGroupRepository = hotelGroupRepository;
            _hotelGroupSecurityRepository = hotelGroupSecurityRepository;
            _password = password;
            _tokenService = tokenService;
        }

        public async Task<GroupLoginReturnDTO> GroupLogin(HotelGroupLoginDTO hotelGroupLoginDTO)
        {
            if(hotelGroupLoginDTO.Email == null||hotelGroupLoginDTO.Password==null)
            {
                throw new ArgumentNullException(nameof(hotelGroupLoginDTO));
            }
            try
            {
                var hotelGroup = await _hotelGroupRepository.GetHotelGroupByEmail(hotelGroupLoginDTO.Email);
                if (hotelGroup == null)
                {
                    throw new ErrorInServiceException();
                }
                var hotelGroupSecurity = await _hotelGroupSecurityRepository.GetByIdAsync(hotelGroup.HotelGroupId);
                if (hotelGroupSecurity.HotelGroupPassword == null || hotelGroupSecurity.HotelGroupPasswordHashKey==null)
                {
                    throw new ErrorInServiceException();
                }
                var IsPassSame = _password.ComparePassword(hotelGroupLoginDTO.Password, hotelGroupSecurity.HotelGroupPassword, hotelGroupSecurity.HotelGroupPasswordHashKey);
                if (IsPassSame)
                {
                    return LoginReturn(hotelGroup);
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
        public GroupLoginReturnDTO LoginReturn(HotelGroup user)
        {
            GroupLoginReturnDTO loginReturnDTO = new GroupLoginReturnDTO()
            {
                GroupEmail = user.HotelGroupEmail,
                GroupId = user.HotelGroupId,
                Role = "HotelGroup",
                Token = _tokenService.GenerateHotelGroupToken(user)
            }; 
            return loginReturnDTO;
        }
    }
}

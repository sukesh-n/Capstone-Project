using HotelBookingApp.DTO.GuestDTO;
using HotelBookingApp.Interface.IRepository.IGuest.IGuests;
using HotelBookingApp.Interface.IRepository.IGuests;
using HotelBookingApp.Interface.IService.IGuestService;
using HotelBookingApp.Interface.IToken;
using HotelBookingApp.Models.Guests;
using HotelBookingApp.Services.Hashing;
using Microsoft.IdentityModel.Tokens;

namespace HotelBookingApp.Services.GuestService
{
    public class GuestLoginService : IGuestLoginService
    {
        public IGuestRepository _guestRepository;
        public IGuestSecurityRepository _guestSecurityRepository;
        Password _password;
        ITokenService _tokenService;
        public GuestLoginService(IGuestRepository guestRepository, IGuestSecurityRepository guestSecurityRepository, ITokenService tokenService, Password password)
        {
            _guestRepository = guestRepository;
            _guestSecurityRepository = guestSecurityRepository;
            _tokenService = tokenService;
            _password = password;
        }

        public async Task<GuestLoginReturnDTO> GuestLogin(GuestLoginDTO guestLoginDTO)
        {
            if(guestLoginDTO.Email == null || guestLoginDTO.Password == null)
            {
                throw new Exception("Email or Password is empty");
            }
            var GetGuest = await _guestRepository.GetGuestByEmail(guestLoginDTO.Email);
            if(GetGuest == null)
            {
                throw new Exception("Guest not found");
            }
            var GetGuestSecurity = await _guestSecurityRepository.GetByIdAsync(GetGuest.GuestId);
            if(GetGuestSecurity.GuestPassword == null || GetGuestSecurity.GuestPasswordHashKey==null)
            {
                throw new Exception("Guest Security not found");
            }
            var IsPasswordSame = _password.ComparePassword(guestLoginDTO.Password, GetGuestSecurity.GuestPassword, GetGuestSecurity.GuestPasswordHashKey);
            if (IsPasswordSame)
            {
                return LoginReturn(GetGuest);
            }
            else
            {
                throw new Exception("Password is incorrect");
            }

        }
        public GuestLoginReturnDTO LoginReturn(Guest user)
        {
            GuestLoginReturnDTO loginReturnDTO = new GuestLoginReturnDTO()
            {
                GuestEmail = user.GuestEmail,
                GuestId = user.GuestId,
                Role = "Guest",
                token = _tokenService.GenerateGuestToken(user)
            }; return loginReturnDTO;
        }
    }
}

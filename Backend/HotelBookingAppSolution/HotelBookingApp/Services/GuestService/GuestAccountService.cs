using HotelBookingApp.DTO.GuestDTO;
using HotelBookingApp.Exceptions;
using HotelBookingApp.Interface.IRepository.IGuest.IGuests;
using HotelBookingApp.Interface.IRepository.IGuests;
using HotelBookingApp.Interface.IService.IGuestService;
using HotelBookingApp.Models.Guests;
using HotelBookingApp.Services.Hashing;

namespace HotelBookingApp.Services.GuestService
{
    public class GuestAccountService : IGuestAccountService
    {
        public readonly IGuestRepository _guestRepository;
        public readonly IGuestSecurityRepository _guestSecurityRepository;
        public readonly Password _password;

        public GuestAccountService(IGuestRepository guestRepository, IGuestSecurityRepository guestSecurityRepository, Password password)
        {
            _guestRepository = guestRepository;
            _guestSecurityRepository = guestSecurityRepository;
            _password = password;
        }

        public async Task<GuestAccountDTO> AddNewGuest(GuestAccountDTO guestAccountDTO)
        {
            if(guestAccountDTO.Guest == null || guestAccountDTO.Password==null)
            {
                throw new ArgumentNullException("Guest Account is null");
            }
            try
            {
                var CheckExistingGuest = await _guestRepository.GetGuestByEmail(guestAccountDTO.Guest.GuestEmail);
                if(CheckExistingGuest != null)
                {
                    throw new Exception("Guest already exists");
                }
                var AddGuest = await _guestRepository.AddAsync(guestAccountDTO.Guest);
                if(AddGuest == null)
                {
                    throw new Exception("Error in connecting to the repository");
                }
                var PasswordHash = _password.PasswordHashing(guestAccountDTO.Password);
                var SecurityDTO = new GuestSecurity
                {
                    Guest = guestAccountDTO.Guest,
                    GuestId = AddGuest.GuestId,
                    GuestPasswordHashKey=PasswordHash.PasswordHashKey_,
                    GuestPassword=PasswordHash.PasswordByte
                };
                var AddGuestSecurity = await _guestSecurityRepository.AddAsync(SecurityDTO);
                if(AddGuestSecurity == null)
                {
                    throw new Exception("Error in connecting to the repository");
                }
                return new GuestAccountDTO
                {
                    Guest = AddGuest,
                    Password = guestAccountDTO.Password
                };
            }
            catch (Exception ex)
            {
                throw new ErrorInServiceException("Error in connecting to the repository", ex);
            }
        }

        public async Task<GuestAccountDTO> DeleteGuest(int guestId)
        {
            try
            {
                //var GetSecurity = await _guestSecurityRepository.GetByIdAsync(guestId);

                //var DeleteSecurity = await _guestSecurityRepository.DeleteAsync(guestId);
                var DeleteGuest = await _guestRepository.DeleteAsync(guestId);
                if (DeleteGuest == false)
                {
                    throw new Exception("Error in connecting to the repository");
                }
                return new GuestAccountDTO
                {
                    Guest = null,
                    Password = null
                };
            }
            catch (Exception ex)
            {
                throw new ErrorInServiceException("Error in connecting to the repository", ex);
            }
        }

        public Task<IEnumerable<GuestDTO>> GetAllGuests()
        {
            throw new NotImplementedException();
        }

        public Task<GuestDTO> GetGuest(int guestId)
        {
            throw new NotImplementedException();
        }

        public async Task<GuestAccountDTO> UpdateGuest(GuestAccountDTO guestAccountDTO)
        {
            if(guestAccountDTO.Guest == null)
            {
                throw new ArgumentNullException("Guest Account is null");
            }
            try
            {
                var CheckExistingGuest = await _guestRepository.GetByIdAsync(guestAccountDTO.Guest.GuestId);
                if(CheckExistingGuest == null)
                {
                    throw new Exception("Guest does not exist");
                }

                var UpdateGuest = await _guestRepository.UpdateAsync(guestAccountDTO.Guest);
                if(UpdateGuest == null)
                {
                    throw new Exception("Error in connecting to the repository");
                }
                return new GuestAccountDTO
                {
                    Guest = UpdateGuest,
                    Password = guestAccountDTO.Password
                };
            }
            catch (Exception ex)
            {
                throw new ErrorInServiceException("Error in connecting to the repository", ex);
            }
        }

        public async Task<GuestAccountDTO> UpdateGuestSecurity(string email, string password)
        {
            try
            {
                var GetGuest = await _guestRepository.GetGuestByEmail(email);
                if (GetGuest == null)
                {
                    throw new Exception("Guest does not exist");
                }


                //GenerateOTPInMail
                //OtpGeneration();
                //var Security = await _guestSecurityRepository.GetByIdAsync(GetGuest.GuestId);
                var PasswordHash = _password.PasswordHashing(password);
                var SecurityDTO = new GuestSecurity
                {
                    GuestId = GetGuest.GuestId,
                    GuestPasswordHashKey = PasswordHash.PasswordHashKey_,
                    GuestPassword = PasswordHash.PasswordByte

                };
                var SecurityUpdate = await _guestSecurityRepository.UpdateAsync(SecurityDTO);
                if (SecurityUpdate == null)
                {
                    throw new Exception("Error in connecting to the repository");
                }
                return new GuestAccountDTO
                {
                    Guest = GetGuest,
                    Password = password
                };
            }
            catch (Exception ex)
            {
                throw new ErrorInServiceException("Error in connecting to the repository", ex);
            }
        }
    }
}

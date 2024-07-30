using HotelBookingApp.DTO.GuestDTO;
using HotelBookingApp.Exceptions;
using HotelBookingApp.Interface.IRepository.IGuest.IGuests;
using HotelBookingApp.Interface.IRepository.IGuests;
using HotelBookingApp.Interface.IService.IGuestService;

namespace HotelBookingApp.Services.GuestService
{
    public class GuestDemographicsService : IGuestDemographicsService
    {
        public readonly IGuestDemographicsRepository _guestDemographicsRepository;
        public readonly IGuestRepository _guestRepository;

        public GuestDemographicsService(IGuestDemographicsRepository guestDemographicsRepository, IGuestRepository guestRepository)
        {
            _guestDemographicsRepository = guestDemographicsRepository;
            _guestRepository = guestRepository;
        }

        public async Task<GuestDemographicsDTO> AddGuestDemographics(GuestDemographicsDTO guestDemographicsDTO)
        {
            if(guestDemographicsDTO.GuestDemographics == null)
            {
                throw new ArgumentNullException("Guest Demographics is null");
            }
            try
            {
                var GetGuest = await _guestRepository.GetByIdAsync(guestDemographicsDTO.GuestId);
                if (GetGuest == null)
                {
                    throw new ErrorInServiceException("Guest does not exist");
                }
                guestDemographicsDTO.GuestDemographics.Guest = GetGuest;
                var AddGuestDemographics = await _guestDemographicsRepository.AddAsync(guestDemographicsDTO.GuestDemographics);
                if (AddGuestDemographics == null)
                {
                    throw new ErrorInServiceException("Error in connecting to the repository");
                }
                return new GuestDemographicsDTO
                {
                    GuestId = guestDemographicsDTO.GuestId,
                    GuestDemographics = AddGuestDemographics
                };
            }
            catch (Exception ex)
            {
                throw new ErrorInServiceException("Error in connecting to the repository", ex);
            }
        }

        public Task<GuestDemographicsDTO> DeleteGuestDemographics(int guestId)
        {
            throw new NotImplementedException();
        }

        public async Task<GuestDemographicsDTO> GetGuestDemographics(int guestId)
        {
            try
            {
                var GetGuestDemographics = await _guestDemographicsRepository.GetByIdAsync(guestId);
                if (GetGuestDemographics == null)
                {
                    throw new ErrorInServiceException("Guest Demographics does not exist");
                }
                return new GuestDemographicsDTO
                {
                    GuestId = guestId,
                    GuestDemographics = GetGuestDemographics
                };
            }
            catch (Exception ex)
            {
                throw new ErrorInServiceException("Error in connecting to the repository", ex);
            }
        }

        public async Task<GuestDemographicsDTO> UpdateGuestDemographics(GuestDemographicsDTO guestDemographicsDTO)
        {
            if (guestDemographicsDTO.GuestDemographics == null)
            {
                throw new ArgumentNullException("Guest Demographics is null");
            }
            try
            {
                var GetGuest = await _guestRepository.GetByIdAsync(guestDemographicsDTO.GuestId);
                if (GetGuest == null)
                {
                    throw new ErrorInServiceException("Guest does not exist");
                }
                guestDemographicsDTO.GuestDemographics.Guest = GetGuest;
                var ExistingGuestDemographics = await _guestDemographicsRepository.GetByIdAsync(guestDemographicsDTO.GuestId);
                if (ExistingGuestDemographics == null)
                {
                    var NewDemographicsResult = await AddGuestDemographics(guestDemographicsDTO);
                    if (NewDemographicsResult == null)
                    {
                        throw new ErrorInServiceException("Error in connecting to the repository");
                    }
                    return new GuestDemographicsDTO
                    {
                        GuestId = guestDemographicsDTO.GuestId,
                        GuestDemographics = NewDemographicsResult.GuestDemographics
                    };

                }
                var UpdateGuestDemographics = await _guestDemographicsRepository.UpdateAsync(guestDemographicsDTO.GuestDemographics);
                if (UpdateGuestDemographics == null)
                {
                    throw new ErrorInServiceException("Error in connecting to the repository");
                }
                return new GuestDemographicsDTO
                {
                    GuestId = guestDemographicsDTO.GuestId,
                    GuestDemographics = UpdateGuestDemographics
                };
            }
            catch (Exception ex)
            {
                throw new ErrorInServiceException("Error in connecting to the repository", ex);
            }
        }
    }
}

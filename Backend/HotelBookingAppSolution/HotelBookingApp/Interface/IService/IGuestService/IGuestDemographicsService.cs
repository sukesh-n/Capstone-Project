using HotelBookingApp.DTO.GuestDTO;

namespace HotelBookingApp.Interface.IService.IGuestService
{
    public interface IGuestDemographicsService
    {
        Task<GuestDemographicsDTO> AddGuestDemographics(GuestDemographicsDTO guestDemographicsDTO);
        Task<GuestDemographicsDTO> UpdateGuestDemographics(GuestDemographicsDTO guestDemographicsDTO);
        Task<GuestDemographicsDTO> DeleteGuestDemographics(int guestId);
        Task<GuestDemographicsDTO> GetGuestDemographics(int guestId);
    }
}

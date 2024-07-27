using HotelBookingApp.Models.Hotels.HotelGroups;

namespace HotelBookingApp.DTO.HotelGroupDTO
{
    public class HotelGroupsDTO : HotelGroup
    {
        public HotelGroup? HotelGroupDemographics { get; set; }
        
    }
}

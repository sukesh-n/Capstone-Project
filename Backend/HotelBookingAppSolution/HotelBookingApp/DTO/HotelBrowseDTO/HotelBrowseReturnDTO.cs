using HotelBookingApp.Models.Hotels;

namespace HotelBookingApp.DTO.HotelBrowseDTO
{
    public class HotelBrowseReturnDTO
    {
        public int HotelId { get; set; }
        public string? HotelBranchName { get; set; }
        public bool? IsAvailable { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public HotelDemographics? HotelDemographics { get; set; }
        public EnumHotelType? HotelType { get; set; }        

    }
}

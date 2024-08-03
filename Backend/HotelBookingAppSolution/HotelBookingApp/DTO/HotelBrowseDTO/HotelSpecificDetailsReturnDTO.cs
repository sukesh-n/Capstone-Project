using HotelBookingApp.Models.Hotels;
using HotelBookingApp.Models.Hotels.HotelBranches;

namespace HotelBookingApp.DTO.HotelBrowseDTO
{
    public class HotelSpecificDetailsReturnDTO
    {
        public int HotelBranchId { get; set; }
        public HotelBranch? HotelBranch { get; set; }
        public RoomType? RoomType { get; set; }
        public RoomAmenities? RoomAmenities { get; set; }
        public HotelBranchRules? HotelBranchRules { get; set; }
        public HotelDemographics? HotelDemographics { get; set; }

    }
}

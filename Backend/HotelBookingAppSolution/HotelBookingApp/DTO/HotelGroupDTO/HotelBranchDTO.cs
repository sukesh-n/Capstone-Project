using HotelBookingApp.Models.Hotels;
using HotelBookingApp.Models.Hotels.HotelBranches;
using System.Diagnostics.CodeAnalysis;

namespace HotelBookingApp.DTO.HotelGroupDTO
{
    public class HotelBranchDTO : HotelBranch
    {
        public RoomType? RoomType { get; set; }
        public RoomAmenities? RoomAmenities { get; set; }
        public HotelImages? HotelImages { get; set; }
        public HotelDemographics? HotelDemographics { get; set; }
        public HotelBranchRules? HotelBranchRules { get; set; }
        public HotelAmenities? HotelAmenities { get; set; }
        
    }
}

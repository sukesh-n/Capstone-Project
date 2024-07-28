using HotelBookingApp.Models.Hotels.HotelBranches;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApp.Models.Hotels
{
    public class HotelDemographics
    {
        [Key]
        public int HotelId { get; set; }
        public string HotelAddressLine1 { get; set; } = string.Empty;
        public string HotelAddressLine2 { get; set; } = string.Empty;
        public string HotelCity { get; set; } = string.Empty;
        public string HotelState { get; set; } = string.Empty;
        public string HotelCountry { get; set; } = string.Empty;
        public string HotelZipCode { get; set; } = string.Empty;
        public string LandMark { get; set; } = string.Empty;
        public string MapCoordinates { get; set; } = string.Empty;
        public string NearestAirport { get; set; } = string.Empty;
        public float DistanceFromAirport { get; set; }
        public string NearestRailwayStation { get; set; } = string.Empty;
        public float DistanceFromRailwayStation { get; set; }
        public string NearestBusStand { get; set; } = string.Empty;
        public float DistanceFromBusStand { get; set; }
        [ForeignKey("HotelId")]
        public HotelBranch? Hotel { get; set; }
    }
}

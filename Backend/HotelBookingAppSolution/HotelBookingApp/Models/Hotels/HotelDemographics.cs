using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApp.Models.Hotels
{
    public class HotelDemographics
    {
        [ForeignKey("HotelId")]
        public int HotelId { get; set; }
        public string HotelAddressLine1 { get; set; } = string.Empty;
        public string HotelAddressLine2 { get; set; } = string.Empty;
        public string HotelCity { get; set; } = string.Empty;
        public string HotelState { get; set; } = string.Empty;
        public string HotelCountry { get; set; } = string.Empty;
        public string HotelZipCode { get; set; } = string.Empty;
        public string LandMark { get; set; } = string.Empty;
        public string MapCoordinates { get; set; } = string.Empty;

    }
}

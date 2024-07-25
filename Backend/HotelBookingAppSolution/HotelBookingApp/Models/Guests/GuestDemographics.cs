using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApp.Models.Guests
{
    public class GuestDemographics
    {
        [ForeignKey("GuestId")]
        public int GuestId { get; set; }
        public int DoorNumber { get; set; }
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;

    }
}

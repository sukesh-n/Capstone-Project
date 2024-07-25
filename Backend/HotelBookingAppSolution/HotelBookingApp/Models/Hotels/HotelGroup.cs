using System.ComponentModel.DataAnnotations;

namespace HotelBookingApp.Models.Hotel
{
    public class HotelGroup
    {
        [Key]
        public int HotelGroupId { get; set; }
        public string HotelGroupName { get; set; } = string.Empty;
        public string HotelGroupManagerName { get; set; } = string.Empty;
        public string HotelGroupEmail { get; set; } = string.Empty;
        public string HotelGroupPhone { get; set; } = string.Empty;
    }
}

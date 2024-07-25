using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApp.Models.Hotel
{
    public class Hotel
    {
        [ForeignKey("HotelGroupId")]
        public int HotelGroupId { get; set; }
        [Key]
        public int HotelId { get; set; }
        public string HotelName { get; set; } = string.Empty;
        public string HotelManager { get; set; } = string.Empty;
        public string HotelEmail { get; set; } = string.Empty;
        public string HotelPhone { get; set; } = string.Empty;
    }
}

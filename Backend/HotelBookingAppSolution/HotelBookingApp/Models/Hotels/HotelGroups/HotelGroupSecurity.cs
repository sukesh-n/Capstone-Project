using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApp.Models.Hotels.HotelGroups
{
    public class HotelGroupSecurity
    {
        [ForeignKey("HotelGroupId")]
        public int HotelGroupId { get; set; }
        public byte[]? HotelGroupPassword { get; set; }
        public byte[]? HotelGroupPasswordHashKey { get; set; }
    }
}
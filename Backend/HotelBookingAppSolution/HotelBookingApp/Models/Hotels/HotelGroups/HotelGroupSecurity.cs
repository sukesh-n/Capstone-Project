using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApp.Models.Hotels.HotelGroups
{
    public class HotelGroupSecurity
    {
        [Key]
        public int HotelGroupId { get; set; }
        public byte[]? HotelGroupPassword { get; set; }
        public byte[]? HotelGroupPasswordHashKey { get; set; }
        [ForeignKey("HotelGroupId")]
        public HotelGroup? HotelGroup { get; set; }
    }
}
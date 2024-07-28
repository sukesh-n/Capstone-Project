using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApp.Models.Guests
{
    public class GuestSecurity
    {
        [Key]
        public int GuestId { get; set; }
        public byte[]? GuestPassword { get; set; }
        public byte[]? GuestPasswordHashKey { get; set; }
        [ForeignKey("GuestId")]
        public Guest? Guest { get; set; }
    }
}

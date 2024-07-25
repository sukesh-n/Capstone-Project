using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApp.Models.Guests
{
    public class GuestSecurity
    {
        [ForeignKey("GuestId")]
        public int GuestId { get; set; }
        public byte[]? GuestPassword { get; set; }
        public byte[]? GuestPasswordHashKey { get; set; }

    }
}

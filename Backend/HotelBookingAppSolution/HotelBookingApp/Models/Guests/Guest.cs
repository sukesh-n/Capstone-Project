using System.ComponentModel.DataAnnotations;

namespace HotelBookingApp.Models.Guests
{
    public class Guest
    {
        [Key]
        public int GuestId { get; set; }
        public string GuestName { get; set; } = string.Empty;
        public string GuestEmail { get; set; } = string.Empty;
        public string GuestPhone { get; set; } = string.Empty;
    }
}

using HotelBookingApp.Models.Guests;

namespace HotelBookingApp.DTO.GuestDTO
{
    public class GuestAccountDTO
    {
        public Guest? Guest { get; set; }
        public string? Password { get; set; }
    }
}

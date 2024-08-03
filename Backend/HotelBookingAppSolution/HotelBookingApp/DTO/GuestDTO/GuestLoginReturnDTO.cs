namespace HotelBookingApp.DTO.GuestDTO
{
    public class GuestLoginReturnDTO
    {
        public int GuestId { get; set; }
        public string? Role { get; set; }
        public string? GuestEmail { get; set; }
        public string? token { get; set; }
    }
}

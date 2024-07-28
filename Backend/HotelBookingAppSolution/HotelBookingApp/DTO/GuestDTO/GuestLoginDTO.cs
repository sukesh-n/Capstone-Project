namespace HotelBookingApp.DTO.GuestDTO
{
    public class GuestLoginDTO : LoginDTO
    {
        public string Role { get; set; } = "guest";
    }
}

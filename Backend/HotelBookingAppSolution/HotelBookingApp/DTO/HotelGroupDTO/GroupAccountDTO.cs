using HotelBookingApp.Models.Hotels.HotelGroups;

namespace HotelBookingApp.DTO.HotelGroupDTO
{
    public class GroupAccountDTO
    {
        public HotelGroup? HotelGroup { get; set; }
        public string Password { get; set; } = string.Empty;
    }
}

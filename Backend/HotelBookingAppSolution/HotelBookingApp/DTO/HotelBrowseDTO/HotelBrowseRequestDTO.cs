namespace HotelBookingApp.DTO.HotelBrowseDTO
{
    public class HotelBrowseRequestDTO
    {
        public int AdultCount { get; set; }
        public int ChildCount { get; set; }
        public int RoomCount { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string? State { get; set; }
        public string? District { get; set; }
    }
}

using HotelBookingApp.Models.Hotels;

namespace HotelBookingApp.DTO.HotelBranchDTO
{
    public class BranchRoomDetailsDTO
    {
        public int HotelBranchId { get; set; }
        public int RoomTypeId { get; set; }
        public string? RoomTypeName { get; set; }
        public int CurrentAvailableRooms { get; set; }
        public int NoOfCurrentBookings { get; set; }
    }
}

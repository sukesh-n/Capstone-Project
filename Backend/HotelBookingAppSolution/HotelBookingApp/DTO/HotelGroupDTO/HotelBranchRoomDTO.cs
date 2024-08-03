using HotelBookingApp.Models.Hotels;

namespace HotelBookingApp.DTO.HotelGroupDTO
{
    public class HotelBranchRoomDTO
    {
        public int HotelBranchId { get; set; }
        public RoomType RoomType { get; set; } = new RoomType();
        public RoomAmenities RoomAmenities { get; set; } = new RoomAmenities();
    }
} 

using HotelBookingApp.Models.Hotels;

namespace HotelBookingApp.DTO.HotelBrowseDTO
{
    public class BranchRoomTypeFetchReturnDTO
    {
        public int BranchId { get; set; }
        public int RoomTypeId { get; set; }
        public EnumRoomTypes RoomType { get; set; }
        public decimal PriceDay { get; set; }
        public bool IsAvailable { get; set; } 
        public int NumberOfRoomsAvailable { get; set; }

    }
}

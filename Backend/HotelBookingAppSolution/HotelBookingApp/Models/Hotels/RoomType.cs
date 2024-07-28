using HotelBookingApp.Models.Hotels.HotelBranches;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApp.Models.Hotels
{
    public class RoomType
    {
        [Key]
        public int RoomTypeId { get; set; }
        [Required]
        public int HotelBranchId { get; set; }
        public EnumRoomTypes RoomTypeName { get; set; }
        public string RoomTypeDescription { get; set; } = string.Empty;
        public int NumberOfRooms { get; set; }
        public float RoomPrice { get; set; }
        public int NumberOfAdults { get; set; }
        public int NumberOfBed { get; set; }
        [ForeignKey("HotelBranchId")]
        public HotelBranch? HotelBranch { get; set; }
    }
}

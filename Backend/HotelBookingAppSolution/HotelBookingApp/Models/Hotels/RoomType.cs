using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApp.Models.Hotels
{
    public class RoomType
    {
        [Key]
        public int RoomTypeId { get; set; }
        [Required]
        [ForeignKey("HotelBranchId")]
        public int HotelBranchId { get; set; }
        public string RoomTypeName { get; set; } = string.Empty;
        public int NumberOfRooms { get; set; }
        public float RoomPrice { get; set; }
        public int NumberOfAdults { get; set; }
        public int NumberOfBed { get; set; }

        
    }
}

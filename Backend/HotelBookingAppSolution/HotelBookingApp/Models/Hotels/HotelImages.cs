using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApp.Models.Hotels
{
    public class HotelImages
    {
        [ForeignKey("HotelBranchId")]
        public int HotelBranchId { get; set; }
        public byte[]? RoomImage { get; set; }
    }
}

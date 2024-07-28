using HotelBookingApp.Models.Hotels.HotelBranches;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApp.Models.Hotels
{
    public class HotelImages
    {
        [Key]
        public int HotelBranchId { get; set; }
        public int RoomTypeId { get; set; }
        public byte[]? RoomImage { get; set; }
        [ForeignKey("HotelBranchId")]
        public HotelBranch? Hotel { get; set; }
        [ForeignKey("RoomTypeId")]
        public RoomType? RoomType { get; set; }
    }
}

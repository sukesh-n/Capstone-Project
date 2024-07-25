using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApp.Models.Hotels.HotelBranch
{
    public class HotelBranchSecurity
    {
        [ForeignKey("HotelBranchId")]
        public int HotelBranchId { get; set; }
        public byte[]? HotelBranchPassword { get; set; }
        public byte[]? HotelBranchPasswordHashKey { get; set; } 
    }
}

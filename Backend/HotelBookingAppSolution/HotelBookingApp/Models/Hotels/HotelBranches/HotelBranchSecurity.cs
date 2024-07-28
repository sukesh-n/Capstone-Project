using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApp.Models.Hotels.HotelBranches
{
    public class HotelBranchSecurity
    {
        [Key]
        public int HotelBranchId { get; set; }
        public byte[]? HotelBranchPassword { get; set; }
        public byte[]? HotelBranchPasswordHashKey { get; set; }
        [ForeignKey("HotelBranchId")]
        public HotelBranch? HotelBranch { get; set; }   
    }
}

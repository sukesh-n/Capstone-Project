using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApp.Models.Hotels.HotelBranches
{
    public class Hotel
    {
        [ForeignKey("HotelGroupId")]
        public int HotelGroupId { get; set; }
        [Key]
        public int HotelBranchId { get; set; }
        public string HotelBranchName { get; set; } = string.Empty;
        public string HotelBranchManager { get; set; } = string.Empty;
        public string HotelBranchEmail { get; set; } = string.Empty;
        public string HotelBranchPhone { get; set; } = string.Empty;

    }
}

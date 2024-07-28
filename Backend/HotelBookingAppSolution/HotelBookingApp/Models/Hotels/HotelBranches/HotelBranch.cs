using HotelBookingApp.Models.Hotels.HotelGroups;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApp.Models.Hotels.HotelBranches
{
    public class HotelBranch
    {
        public int HotelGroupId { get; set; }
        [Required]
        [Key]
        public int HotelBranchId { get; set; }
        public string HotelBranchName { get; set; } = string.Empty;
        public EnumHotelType HotelType { get; set; }
        public string HotelBranchManager { get; set; } = string.Empty;
        public string HotelBranchEmail { get; set; } = string.Empty;
        public string HotelBranchPhone { get; set; } = string.Empty;
        [ForeignKey("HotelGroupId")]
        public HotelGroup? HotelGroup { get; set; }
    }
}

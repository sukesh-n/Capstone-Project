using HotelBookingApp.Models.Hotels.HotelBranches;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApp.Models.Hotels
{
    public class HotelBranchRules
    {
        [Key]
        public int HotelBranchId { get; set; }
        public TimeSpan CheckInTime { get; set; }
        public TimeSpan CheckOutTime { get; set; }
        public bool CanCheckInEarly { get; set; }
        public bool CanCheckOutLate { get; set; }
        [ForeignKey("HotelBranchId")]
        public HotelBranch? Hotel { get; set; }
    }
}

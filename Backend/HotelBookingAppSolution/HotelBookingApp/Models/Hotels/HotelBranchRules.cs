using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApp.Models.Hotels
{
    public class HotelBranchRules
    {
        [ForeignKey("HotelBranchId")]
        public int HotelBranchId { get; set; }
        public TimeOnly CheckInTime { get; set; }
        public TimeOnly CheckOutTime { get; set; }
        public bool CanCheckInEarly { get; set; }
        public bool CanCheckOutLate { get; set; }
    }
}

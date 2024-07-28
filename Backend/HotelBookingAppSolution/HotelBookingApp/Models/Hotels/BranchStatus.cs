using HotelBookingApp.Models.Hotels.HotelBranches;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApp.Models.Hotels
{
    public class BranchStatus
    {
        [Key]
        public int HotelBranchId { get; set; }
        public bool IsAvailable { get; set; }
        public int AvailableRooms { get; set; }
        public int BookedRooms { get; set; }
        public DateTime PlannedClosureFrom { get; set; }
        public DateTime PlannedClosureTo { get; set; }
        public DateTime LastUpdated { get; set; }
        [ForeignKey("HotelBranchId")]
        public HotelBranch? HotelBranch { get; set; }
    }
}

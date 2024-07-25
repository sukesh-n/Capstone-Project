using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApp.Models.Hotels
{
    public class BranchStatus
    {
        [ForeignKey("HotelBranchId")]
        public int HotelBranchId { get; set; }
        public bool IsAvailable { get; set; }
        public int AvailableRooms { get; set; }
        public int BookedRooms { get; set; }
        public DateTime PlannedClosureFrom { get; set; }
        public DateTime PlannedClosureTo { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}

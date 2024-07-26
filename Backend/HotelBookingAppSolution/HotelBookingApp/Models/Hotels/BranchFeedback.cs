using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApp.Models.Hotels
{
    public class BranchFeedback
    {
        [ForeignKey("HotelBranchId")]
        public int HotelBranchId { get; set; }
        public int TotalRating { get; set; } = 0;
        public float AverageRating { get; set; }
    }
}

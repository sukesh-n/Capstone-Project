using HotelBookingApp.Models.Hotels.HotelBranches;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApp.Models.Hotels
{
    public class BranchFeedback
    {
        [Key]
        public int BranchFeedbackId { get; set; }
        public int HotelBranchId { get; set; }
        public int TotalRating { get; set; } = 0;
        public float AverageRating { get; set; }
        [ForeignKey("HotelBranchId")]
        public HotelBranch? HotelBranches { get; set; }
    }
}

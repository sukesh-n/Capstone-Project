using HotelBookingApp.Models.Hotels.HotelBranches;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApp.Models.Payments
{
    public class Revenue
    {
        [Key]
        public int HotelBranchId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalCommissionReceived { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal PendingFeeForCurrentMonth { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal PendingFeeForNextMonth { get; set; }
        [ForeignKey("HotelBranchId")]
        public HotelBranch? HotelBranch { get; set; }
    }
}

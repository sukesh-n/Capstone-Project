using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApp.Models.Payments
{
    public class Revenue
    {
        [ForeignKey("HotelBranchId")]
        public int HotelBranchId { get; set; }
        public float TotalCommissionReceived { get; set; }
        public float PendingFeeForCurrentMonth { get; set; }
        public float PendingFeeForNextMonth { get; set; }
    }
}

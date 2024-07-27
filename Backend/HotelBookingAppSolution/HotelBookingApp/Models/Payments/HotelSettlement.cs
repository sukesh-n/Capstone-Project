using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApp.Models.Payments
{
    public class HotelSettlement
    {
        [Key]
        public int HotelSettlementId { get; set; }
        [ForeignKey("HotelGroupId")]
        public int HotelGroupId { get; set; }
        [ForeignKey("HotelBranchId")]
        public int HotelBranchId { get; set; }
        [ForeignKey("BookingId")]
        public int BookingId { get; set; }
        public float TotalAmountReceivedFromBooking { get; set; }
        public float AmountToBePaid { get; set; }
        public DateTime PayoutDate { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}

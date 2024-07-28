using HotelBookingApp.Models.Booking;
using HotelBookingApp.Models.Hotels.HotelBranches;
using HotelBookingApp.Models.Hotels.HotelGroups;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApp.Models.Payments
{
    public class HotelSettlement
    {
        [Key]
        public int HotelSettlementId { get; set; }
        public int HotelGroupId { get; set; }        
        public int HotelBranchId { get; set; }
        public int BookingId { get; set; }
        public float TotalAmountReceivedFromBooking { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public float AmountToBePaid { get; set; }
        public DateTime PayoutDate { get; set; }
        public DateTime TransactionDate { get; set; }
        [ForeignKey("HotelGroupId")]
        public HotelGroup? HotelGroup { get; set; }
        [ForeignKey("HotelBranchId")]
        public HotelBranch? Hotel { get; set; }
        [ForeignKey("BookingId")]
        public BookingHistory? BookingHistory { get; set; }
    }
}

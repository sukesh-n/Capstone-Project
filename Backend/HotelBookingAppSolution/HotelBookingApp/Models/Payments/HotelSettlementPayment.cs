using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApp.Models.Payments
{
    public class HotelSettlementPayment
    {
        [Key]
        public int HotelSettlementPaymentId { get; set; }
        [ForeignKey("HotelSettlementId")]
        public int HotelSettlementId { get; set; }
        public EnumPaymentStatus SettlementPaymentStatus { get; set; }
        public DateTime PaymentDate { get; set; }
        public EnumPaymentMethod SettlementPaymentMethod { get; set; }
         
    }
}

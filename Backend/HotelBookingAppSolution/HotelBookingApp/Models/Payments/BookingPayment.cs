using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApp.Models.Payment
{
    public class BookingPayment
    {
        [Key]
        public int BookingPaymentId { get; set; }
        [ForeignKey("BookingId")]
        public int BookingId { get; set; }
        public decimal AmountPaid { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;

    }
}

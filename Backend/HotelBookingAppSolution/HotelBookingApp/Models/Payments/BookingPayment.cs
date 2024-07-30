using HotelBookingApp.Models.Booking;
using HotelBookingApp.Models.Payments;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApp.Models.Payment
{
    public class BookingPayment
    {
        [Key]
        public int BookingPaymentId { get; set; }
        public int BookingId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmountForBooking { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal AdvanceAmount { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal HotelAmount { get; set; }
        public EnumPaymentStatus AdvancePaymentStatus { get; set; }
        public EnumPaymentStatus HotelPaymentStatus { get; set; }
        public EnumPaymentMethod AdvancePaymentMethod { get; set; }
        public string? AdvancePaymentTransactionId { get; set; }
        public DateTime AdvancePaymentDate { get; set; }
        public EnumPaymentMethod HotelPaymentMethod { get; set; }
        public string? HotelPaymentTransactionId { get; set; }
        public DateTime HotelPaymentDate { get; set; }
        [ForeignKey("BookingId")]
        public BookingHistory? Booking { get; set; }

    }
}

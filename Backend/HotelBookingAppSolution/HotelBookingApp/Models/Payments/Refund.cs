﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApp.Models.Payments
{
    public class Refund
    {
        [Key]
        public int RefundId { get; set; }
        [ForeignKey("BookingPaymentId")]
        public int BookingPaymentId { get; set; }
        public bool IsRefundOnCancellation { get; set; }
        public decimal RefundAmount { get; set; }
        public EnumPaymentMethod RefundMethod { get; set; }
        public EnumPaymentStatus RefundStatus { get; set; }
    }
}

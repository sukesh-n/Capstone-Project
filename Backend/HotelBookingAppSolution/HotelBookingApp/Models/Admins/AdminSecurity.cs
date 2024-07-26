using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApp.Models.Admins
{
    public class AdminSecurity
    {
        [ForeignKey("AdminId")]
        public int AdminId { get; set; }
        public byte[]? AdminPassword { get; set; }
        public byte[]? AdminPasswordHashKey { get; set; }

    }
}

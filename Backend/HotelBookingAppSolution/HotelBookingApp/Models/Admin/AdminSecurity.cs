using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApp.Models.Admin
{
    public class AdminSecurity
    {
        [ForeignKey("AdminId")]
        public int AdminId { get; set; }
        public byte[]? AdminPassword { get; set; }
        public byte[]? AdminPasswordHashKey { get; set; }

    }
}

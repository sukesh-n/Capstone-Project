using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApp.Models.Admins
{
    public class AdminSecurity
    {
        [Key]
        public int AdminId { get; set; }
        public byte[]? AdminPassword { get; set; }
        public byte[]? AdminPasswordHashKey { get; set; }
        [ForeignKey("AdminId")]
        public Admin? Admin { get; set; }

    }
}

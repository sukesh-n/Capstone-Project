using System.ComponentModel.DataAnnotations;

namespace HotelBookingApp.Models.Admins
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        public string AdminName { get; set; } = string.Empty;
        public string AdminEmail { get; set; } = string.Empty;
        public DateTime Lastlogin { get; set; }

    }
}

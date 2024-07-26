using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApp.Models.Hotels
{
    public class GroupFeedback
    {
        [ForeignKey("HotelGroupId")]
        public int HotelGroupId { get; set; }
        public int TotalRating { get; set; } = 0;
        public float AverageRating { get; set; }

    }
}

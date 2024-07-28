using HotelBookingApp.Models.Hotels.HotelGroups;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApp.Models.Hotels
{
    public class GroupFeedback
    {
        [Key]
        public int GroupFeedbackId { get; set; }
        public int HotelGroupId { get; set; }
        public int TotalRating { get; set; } = 0;
        public float AverageRating { get; set; }
        [ForeignKey("HotelGroupId")]
        public HotelGroup? HotelGroups { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApp.Models.Hotels
{
    public class HotelAmenities
    {
        [ForeignKey("HotelBranchId")]
        public int HotelBranchId { get; set; }
        public bool HasParking { get; set; }
        public bool HasFreePickup { get; set; }

    }
}

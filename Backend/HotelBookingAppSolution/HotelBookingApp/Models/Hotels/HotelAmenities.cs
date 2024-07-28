using HotelBookingApp.Models.Hotels.HotelBranches;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApp.Models.Hotels
{
    public class HotelAmenities
    {
        [Key]
        public int HotelBranchId { get; set; }
        public bool HasParking { get; set; }
        public bool HasFreePickup { get; set; }
        [ForeignKey("HotelBranchId")]
        public HotelBranch? Hotel { get; set; }

    }
}

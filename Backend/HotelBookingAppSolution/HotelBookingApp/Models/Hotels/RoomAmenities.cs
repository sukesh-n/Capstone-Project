using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApp.Models.Hotels
{
    public class RoomAmenities
    {
        [ForeignKey("RoomTypeId")]
        public int RoomTypeId { get; set; }
        public bool IsOnGroundFloor { get; set; }
        public bool HasWifi { get; set; }
        public bool HasTelevision { get; set; }
        public bool HasAirConditioner { get; set; }
        public bool HasRefrigerator { get; set; }
        public bool HasTelephone { get; set; }
        public bool HasAttachedBathroom { get; set; }
        public bool HasRoomService { get; set; }
        public bool HasLaundryService { get; set; }
        public bool HasDoorStepDeliveryService { get; set; }
        public bool IsWithBreakfast { get; set; }
        public bool IsWindowAvailable { get; set; }
        public bool IsBalconyAvailable { get; set; }
        public bool IsBeachViewAvailable { get; set; }
    }
}

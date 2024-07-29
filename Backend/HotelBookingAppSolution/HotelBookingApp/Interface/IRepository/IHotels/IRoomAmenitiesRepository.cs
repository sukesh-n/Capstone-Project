using HotelBookingApp.Models.Hotels;

namespace HotelBookingApp.Interface.IRepository.IHotels
{
    public interface IRoomAmenitiesRepository : IMasterRepository<int,RoomAmenities>
    {
        public Task<RoomAmenities> GetByBranchAndAmenity(int BranchId,int RoomTypeId);
    }
}
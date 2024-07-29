using HotelBookingApp.Models.Hotels;

namespace HotelBookingApp.Interface.IRepository.IHotels
{
    public interface IRoomTypeRepository : IMasterRepository<int,RoomType>
    {
        public Task<RoomType> GetByBranchAndRoomType(int BranchId,EnumRoomTypes EnumRoomTypeId);
    }
}
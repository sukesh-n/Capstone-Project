using HotelBookingApp.DTO.HotelBrowseDTO;

namespace HotelBookingApp.Interface.IService.FreeBrowse
{
    public interface IHotelBrowseService
    {
        public Task<IEnumerable<HotelBrowseReturnDTO>?> FilterHotelByLocationRequest(HotelBrowseRequestDTO hotelBrowseRequestDTO);
        public Task<IEnumerable<BranchRoomTypeFetchReturnDTO>> BranchRoomTypeFetchReturnDTOs(int BranchId,DateTime CheckInTime,DateTime CheckOutTime);
        public Task<List<HotelSpecificDetailsReturnDTO>> FilterHotelByRequest(int BranchId);
    }
}

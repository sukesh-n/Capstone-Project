using HotelBookingApp.DTO.HotelBrowseDTO;

namespace HotelBookingApp.Interface.IService.FreeBrowse
{
    public interface IHotelBrowseService
    {
        public Task<IEnumerable<HotelBrowseReturnDTO>?> FilterHotelByLocationRequest(HotelBrowseRequestDTO hotelBrowseRequestDTO);
        public Task<List<HotelSpecificDetailsReturnDTO>> FilterHotelByRequest(int BranchId);
    }
}

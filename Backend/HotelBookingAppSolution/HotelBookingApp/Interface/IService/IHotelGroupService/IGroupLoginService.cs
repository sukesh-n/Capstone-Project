using HotelBookingApp.DTO.HotelGroupDTO;

namespace HotelBookingApp.Interface.IService.IHotelGroupService
{
    public interface IGroupLoginService
    {
        public Task<HotelGroupLoginDTO> GroupLogin(HotelGroupLoginDTO hotelGroupLoginDTO);

    }
}

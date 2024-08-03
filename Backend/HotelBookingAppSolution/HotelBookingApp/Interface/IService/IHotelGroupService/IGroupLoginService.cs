using HotelBookingApp.DTO.HotelGroupDTO;

namespace HotelBookingApp.Interface.IService.IHotelGroupService
{
    public interface IGroupLoginService
    {
        public Task<GroupLoginReturnDTO> GroupLogin(HotelGroupLoginDTO hotelGroupLoginDTO);

    }
}

using HotelBookingApp.DTO.HotelBranchDTO;

namespace HotelBookingApp.Interface.IService.IHotelBranchService
{
    public interface IBranchLoginService
    {
        public Task<BranchLoginReturnDTO> BranchLogin(HotelBranchLoginDTO hotelBranchLoginDTO);

    }
}

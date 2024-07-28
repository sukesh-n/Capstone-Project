using HotelBookingApp.DTO.HotelBranchDTO;
using HotelBookingApp.Interface.IService.IHotelBranchService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApp.Controllers.HotelBranchController
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelBranchLoginController : ControllerBase
    {
        private readonly IBranchLoginService _hotelBranchLoginService;

        public HotelBranchLoginController(IBranchLoginService hotelBranchLoginService)
        {
            _hotelBranchLoginService = hotelBranchLoginService;
        }

        [HttpPost]
        [Route("HotelBranchLogin")]
        public async Task<IActionResult> HotelBranchLogin(HotelBranchLoginDTO hotelBranchLoginDTO)
        {
            var result = await _hotelBranchLoginService.BranchLogin(hotelBranchLoginDTO);
            return Ok(result);
        }
    }
}

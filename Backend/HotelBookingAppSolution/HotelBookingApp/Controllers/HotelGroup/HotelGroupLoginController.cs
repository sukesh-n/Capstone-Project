using HotelBookingApp.DTO.HotelGroupDTO;
using HotelBookingApp.Interface.IService.IHotelGroupService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApp.Controllers.HotelGroup
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelGroupLoginController : ControllerBase
    {
        private readonly IGroupLoginService _hotelGroupLoginService;

        public HotelGroupLoginController(IGroupLoginService hotelGroupLoginService)
        {
            _hotelGroupLoginService = hotelGroupLoginService;
        }

        [HttpPost]
        [Route("HotelGroupLogin")]
        public async Task<IActionResult> HotelGroupLogin(HotelGroupLoginDTO hotelGroupLoginDTO)
        {
            var result = await _hotelGroupLoginService.GroupLogin(hotelGroupLoginDTO);
            return Ok(result);
        }
    }
}

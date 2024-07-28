using HotelBookingApp.DTO.GuestDTO;
using HotelBookingApp.Interface.IService.IGuestService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApp.Controllers.GuestController
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestLoginController : ControllerBase
    {
        private readonly IGuestLoginService _guestLoginService;

        public GuestLoginController(IGuestLoginService guestLoginService)
        {
            _guestLoginService = guestLoginService;
        }

        [HttpPost]
        [Route("GuestLogin")]
        public async Task<IActionResult> GuestLogin(GuestLoginDTO guestLoginDTO)
        {
            var result = await _guestLoginService.GuestLogin(guestLoginDTO);
            return Ok(result);
        }
    }
}

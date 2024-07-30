using HotelBookingApp.DTO.GuestDTO;
using HotelBookingApp.Interface.IService.IGuestService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApp.Controllers.GuestController
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestAccountController : ControllerBase
    {
        private readonly IGuestAccountService _guestAccountService;

        public GuestAccountController(IGuestAccountService guestAccountService)
        {
            _guestAccountService = guestAccountService;
        }

        [HttpPut]
        [Route("CreateGuestAccount")]
        public async Task<IActionResult> CreateGuestAccount(GuestAccountDTO guestAccountDTO)
        {
            var result = await _guestAccountService.AddNewGuest(guestAccountDTO);
            return Ok(result);
        }
        [HttpPost]
        [Route("UpdateGuestAccount")]
        public async Task<IActionResult> UpdateGuestAccount(GuestAccountDTO guestAccountDTO)
        {
            var result = await _guestAccountService.UpdateGuest(guestAccountDTO);
            return Ok(result);
        }
        [HttpPost]
        [Route("UpdateGuestSecurity")]
        public async Task<IActionResult> UpdateGuestSecurity(string email, string password)
        {
            var result = await _guestAccountService.UpdateGuestSecurity(email, password);
            return Ok(result);
        }
        [HttpDelete]
        [Route("DeleteGuestAccount")]
        public async Task<IActionResult> DeleteGuestAccount(int guestId)
        {
            var result = await _guestAccountService.DeleteGuest(guestId);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetGuestAccount")]
        public async Task<IActionResult> GetGuestAccount(int guestId)
        {
            var result = await _guestAccountService.GetGuest(guestId);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetAllGuests")]
        public async Task<IActionResult> GetAllGuests()
        {
            var result = await _guestAccountService.GetAllGuests();
            return Ok(result);
        }
    }
}

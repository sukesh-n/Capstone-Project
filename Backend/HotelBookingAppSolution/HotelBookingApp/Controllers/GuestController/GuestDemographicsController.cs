using HotelBookingApp.DTO.GuestDTO;
using HotelBookingApp.Interface.IService.IGuestService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApp.Controllers.GuestController
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestDemographicsController : ControllerBase
    {
        private readonly IGuestDemographicsService _guestDemographicsService;

        public GuestDemographicsController(IGuestDemographicsService guestDemographicsService)
        {
            _guestDemographicsService = guestDemographicsService;
        }
        [HttpPut]
        [Route("CreateGuestDemographics")]
        public async Task<IActionResult> CreateGuestDemographics(GuestDemographicsDTO guestDemographicsDTO)
        {
            var result = await _guestDemographicsService.AddGuestDemographics(guestDemographicsDTO);
            return Ok(result);
        }
        [HttpPost]
        [Route("UpdateGuestDemographics")]
        public async Task<IActionResult> UpdateGuestDemographics(GuestDemographicsDTO guestDemographicsDTO)
        {
            var result = await _guestDemographicsService.UpdateGuestDemographics(guestDemographicsDTO);
            return Ok(result);
        }   
        [HttpDelete]
        [Route("DeleteGuestDemographics")]
        public async Task<IActionResult> DeleteGuestDemographics(int guestId)
        {
            var result = await _guestDemographicsService.DeleteGuestDemographics(guestId);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetGuestDemographics")]
        public async Task<IActionResult> GetGuestDemographics(int guestId)
        {
            var result = await _guestDemographicsService.GetGuestDemographics(guestId);
            return Ok(result);
        }


    }
}

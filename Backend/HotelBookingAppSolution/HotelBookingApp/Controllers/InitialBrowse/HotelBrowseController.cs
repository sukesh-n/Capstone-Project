using HotelBookingApp.DTO.HotelBrowseDTO;
using HotelBookingApp.Interface.IService.FreeBrowse;
using HotelBookingApp.Models.Hotels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApp.Controllers.InitialBrowse
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelBrowseController : ControllerBase
    {
        private readonly IHotelBrowseService _hotelBrowseService;

        public HotelBrowseController(IHotelBrowseService hotelBrowseService)
        {
            _hotelBrowseService = hotelBrowseService;
        }

        [HttpPost]
        [Route("GetHotelsByLocation")]
        public async Task<IActionResult> GetHotelsByLocation([FromBody] HotelBrowseRequestDTO hotelBrowseRequestDTO)
        {
            if (hotelBrowseRequestDTO == null)
            {
                return BadRequest("Invalid request data.");
            }

            var result = await _hotelBrowseService.FilterHotelByLocationRequest(hotelBrowseRequestDTO);

            if (result == null || !result.Any())
            {
                return NotFound("No hotels found matching the criteria.");
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("GetDetailsOfSpecificHotel/{hotelId}")]
        public async Task<IActionResult> GetDetailsOfSpecificHotel(int hotelId)
        {
            if (hotelId <= 0)
            {
                return BadRequest("Invalid hotel ID.");
            }

            var result = await _hotelBrowseService.FilterHotelByRequest(hotelId);

            if (result == null)
            {
                return NotFound($"No details found for hotel ID {hotelId}.");
            }

            return Ok(result);
        }
        [HttpPost]
        [Route("GetBranchRoomType")]
        public async Task<IActionResult> GetBranchRoomType(int BranchId, DateTime CheckInTime, DateTime CheckOutTime)
        {
            if (BranchId <= 0)
            {
                return BadRequest("Invalid Branch ID.");
            }

            var result = await _hotelBrowseService.BranchRoomTypeFetchReturnDTOs(BranchId, CheckInTime, CheckOutTime);

            if (result == null)
            {
                return NotFound($"No details found for Branch ID {BranchId}.");
            }

            return Ok(result);
        }
    }
}

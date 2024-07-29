using HotelBookingApp.DTO.HotelGroupDTO;
using HotelBookingApp.Interface.IService.IHotelGroupService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApp.Controllers.HotelGroup
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelGroupManagementController : ControllerBase
    {
        private readonly IHotelGroupManagementService _hotelGroupManagementService;

        public HotelGroupManagementController(IHotelGroupManagementService hotelGroupManagementService)
        {
            _hotelGroupManagementService = hotelGroupManagementService;
        }


        [HttpPost("add")]
        public async Task<IActionResult> AddNewHotelGroup(HotelGroupsDTO addNewHotelGroupDTO)
        {
            try
            {
                var result = await _hotelGroupManagementService.AddHotelGroupDetails(addNewHotelGroupDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateHotelGroup(HotelGroupsDTO HotelGroupDTO)
        {
            try
            {
                var result = await _hotelGroupManagementService.UpdateHotelGroupDetails(HotelGroupDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{hotelGroupId}")]
        public async Task<IActionResult> DeleteHotelGroup(int hotelGroupId)
        {
            try
            {
                var result = await _hotelGroupManagementService.DeleteHotelGroupDetails(hotelGroupId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{hotelGroupId}")]
        public async Task<IActionResult> GetHotelGroup(int hotelGroupId)
        {
            try
            {
                var result = await _hotelGroupManagementService.GetHotelGroupDetails(hotelGroupId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllHotelGroup()
        {
            try
            {
                var result = await _hotelGroupManagementService.GetAllHotelGroupDetails();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}


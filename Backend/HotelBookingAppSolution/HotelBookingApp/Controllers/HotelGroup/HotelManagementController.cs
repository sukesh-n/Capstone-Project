using HotelBookingApp.DTO.HotelGroupDTO;
using HotelBookingApp.Interface.IService.IHotelGroupService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApp.Controllers.HotelGroup
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelManagementController : ControllerBase
    {
        private readonly IHotelManagementService _hotelManagementService;

        public HotelManagementController(IHotelManagementService hotelManagementService)
        {
            _hotelManagementService = hotelManagementService;
        }

        //[HttpPost]
        //[Route("AddNewHotelBranch")]
        //public async Task<IActionResult> AddNewHotelBranch(HotelBranchDTO addNewHotelBranchDTO)
        //{
        //    var result = await _hotelManagementService.AddNewHotelBranch(addNewHotelBranchDTO);
        //    return Ok(result);
        //}

        [HttpPut]
        [Route("UpdateHotelBranch")]
        public async Task<IActionResult> UpdateHotelBranch(HotelBranchDTO updateHotelBranchDTO)
        {
            var result = await _hotelManagementService.UpdateHotelBranch(updateHotelBranchDTO);
            return Ok(result);
        }
        [HttpPut]
        [Route("UpdateHotelBranchRooms")]
        public async Task<IActionResult> UpdateHotelBranchRooms(HotelBranchRoomDTO updateHotelBranchRoomDTO)
        {
            var result = await _hotelManagementService.AddBranchRoom(updateHotelBranchRoomDTO);
            return Ok(result);
        }
        [HttpDelete]
        [Route("DeleteHotelBranch")]
        public async Task<IActionResult> DeleteHotelBranch(int hotelBranchId)
        {
            var result = await _hotelManagementService.DeleteHotelBranch(hotelBranchId);
            return Ok(result);
        }
        [HttpDelete]
        [Route("DeleteHotelRoomType")]
        public async Task<IActionResult> DeleteHotelRoomType(int roomTypeId)
        {
            var result = await _hotelManagementService.DeleteRoomType(roomTypeId);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetHotelBranch")]
        public async Task<IActionResult> GetHotelBranch(int hotelBranchId)
        {
            var result = await _hotelManagementService.GetHotelBranch(hotelBranchId);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetAllHotelBranch")]
        public async Task<IActionResult> GetAllHotelBranch()
        {
            var result = await _hotelManagementService.GetAllHotelBranchUnderGroup();
            return Ok(result);
        }

    }
}

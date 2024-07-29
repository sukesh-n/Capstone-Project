using HotelBookingApp.DTO.HotelGroupDTO;
using HotelBookingApp.Interface.IService.IHotelGroupService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApp.Controllers.HotelGroup
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupAccountController : ControllerBase
    {
        private readonly IGroupAccountService _groupAccountManagementService;

        public GroupAccountController(IGroupAccountService groupAccountManagementService)
        {
            _groupAccountManagementService = groupAccountManagementService;
        }

        [HttpPut]
        [Route("CreateGroupAccount")]
        public async Task<IActionResult> CreateGroupAccount(GroupAccountDTO groupAccountDTO)
        {
            try
            {
               var result = await _groupAccountManagementService.CreateGroupAccount(groupAccountDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [Route("UpdateGroupAccount")]
        public async Task<IActionResult> UpdateGroupAccountSecurity(GroupAccountDTO groupAccountDTO)
        {
            var result = await _groupAccountManagementService.UpdateGroupAccountSecurity(groupAccountDTO);
            return Ok(result);
        }
        [HttpDelete]
        [Route("DeleteGroupAccount")]
        //[Authorize(Roles="admin")]
        public async Task<IActionResult> DeleteGroupAccount(int groupId)
        {
            var result = await _groupAccountManagementService.DeleteGroupAccount(groupId);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetGroupAccount")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetGroupAccount(int groupId)
        {
            var result = await _groupAccountManagementService.GetGroupAccount(groupId);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetAllGroups")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetAllGroups()
        {
            var result = await _groupAccountManagementService.GetAllGroups();
            return Ok(result);
        }
    }
}

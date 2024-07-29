using HotelBookingApp.DTO.HotelGroupDTO;
using HotelBookingApp.Interface.IService.IHotelGroupService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApp.Controllers.HotelGroup
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchAccountController : ControllerBase
    {
        private readonly IBranchAccountService _branchAccountManagementService;

        public BranchAccountController(IBranchAccountService branchAccountManagementService)
        {
            _branchAccountManagementService = branchAccountManagementService;
        }

        [HttpPut]
        [Route("CreateBranchAccount")]
        public async Task<IActionResult> CreateBranchAccount(BranchAccountDTO branchAccountDTO)
        {
            try
            {                 
                var result = await _branchAccountManagementService.CreateBranchAccount(branchAccountDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            
        }
        [HttpPost]
        [Route("UpdateBranchAccount")]
        public async Task<IActionResult> UpdateBranchAccountSecurity(string BranchMail,string Passowrd)
        {
            var result = await _branchAccountManagementService.UpdateBranchAccountSecurity(BranchMail,Passowrd);
            return Ok(result);
        }
        [HttpDelete]
        [Route("DeleteBranchAccount")]
        public async Task<IActionResult> DeleteBranchAccount(int branchId)
        {
            var result = await _branchAccountManagementService.DeleteBranchAccount(branchId);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetBranchAccount")]
        public async Task<IActionResult> GetBranchAccount(int branchId)
        {
            var result = await _branchAccountManagementService.GetBranchAccount(branchId);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetAllBranches")]
        public async Task<IActionResult> GetAllBranches()
        {
            var result = await _branchAccountManagementService.GetAllBranches();
            return Ok(result);
        }
    }
}

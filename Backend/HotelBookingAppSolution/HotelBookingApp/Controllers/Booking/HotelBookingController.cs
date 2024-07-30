using HotelBookingApp.DTO.BookingDTO;
using HotelBookingApp.Interface.IService.IBookingService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApp.Controllers.Booking
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelBookingController : ControllerBase
    {
        private readonly IHotelBookingService _hotelBookingService;

        public HotelBookingController(IHotelBookingService hotelBookingService)
        {
            _hotelBookingService = hotelBookingService;
        }

        [HttpPost]
        [Route("AddNewHotelBooking")]
        public async Task<IActionResult> AddNewHotelBooking(BookingBranchDTO bookingBranchDTO)
        {
            var result = await _hotelBookingService.AddNewHotelBooking(bookingBranchDTO);
            return Ok(result);
        }
        [HttpPost]
        [Route("UpdateHotelBooking")]
        public async Task<IActionResult> UpdateHotelBooking(BookingBranchDTO bookingBranchDTO)
        {
            var result = await _hotelBookingService.UpdateHotelBooking(bookingBranchDTO);
            return Ok(result);
        }
        [HttpDelete]
        [Route("CancelHotelBooking")]
        public async Task<IActionResult> CancelHotelBooking(int hotelBookingId)
        {
            var result = await _hotelBookingService.CancelHotelBooking(hotelBookingId);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetHotelBooking")]
        public async Task<IActionResult> GetHotelBooking(int hotelBookingId)
        {
            var result = await _hotelBookingService.GetHotelBooking(hotelBookingId);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetAllHotelBooking")]
        public async Task<IActionResult> GetAllHotelBooking()
        {
            var result = await _hotelBookingService.GetAllHotelBookingUnderHotel();
            return Ok(result);
        }

    }
}
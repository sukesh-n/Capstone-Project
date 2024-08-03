using HotelBookingApp.Models.Hotels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApp.Controllers.EnumController
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnumRoomTypesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetRoomTypes()
        {
            var roomTypes = Enum.GetValues(typeof(EnumRoomTypes))
                                 .Cast<EnumRoomTypes>()
                                 .Select(e => new
                                 {
                                     Id = (int)e,
                                     Name = e.ToString()
                                 });

            return Ok(roomTypes);
        }
    }
}

using HotelBookingApp.Models.Hotels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApp.Controllers.EnumController
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnumHotelTypesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetHotelTypes()
        {
            var hotelTypes = Enum.GetValues(typeof(EnumHotelType))
                                 .Cast<EnumHotelType>()
                                 .Select(e => new
                                 {
                                     Id = (int)e,
                                     Name = e.ToString()
                                 });

            return Ok(hotelTypes);
        }
    }
}

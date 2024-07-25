using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Context
{
    public class HotelBookingAppContext : DbContext
    {
        public HotelBookingAppContext(DbContextOptions options) : base(options)
        {
        }

    }
}

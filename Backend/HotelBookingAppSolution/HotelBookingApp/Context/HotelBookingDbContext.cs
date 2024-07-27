using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Context
{
    public class HotelBookingDbContext : DbContext
    {
        public HotelBookingDbContext(DbContextOptions options) : base(options)
        {
        }

    }
}

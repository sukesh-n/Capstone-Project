using HotelBookingApp.Context;
using HotelBookingApp.Interface.IRepository.IHotels.IHotelGroups;
using HotelBookingApp.Models.Hotels.HotelGroups;

namespace HotelBookingApp.Repositories.HotelsRepository.HotelGroupsRepository
{
    public class HotelGroupSecurityRepository : IHotelGroupSecurityRepository
    {
        public readonly HotelBookingDbContext _context;

        public HotelGroupSecurityRepository(HotelBookingDbContext context)
        {
            _context = context;
        }

        public async Task<HotelGroupSecurity> AddAsync(HotelGroupSecurity enitity)
        {
            try
            {
                var AddSecurity = await _context.HotelGroupSecurities.AddAsync(enitity);
                if (AddSecurity == null)
                {
                    throw new ErrorInConnectingRepository("Error: Security not added");
                }
                return AddSecurity.Entity;
            }
            catch (Exception ex)
            {
                throw new ErrorInConnectingRepository($"Error: {ex.Message}");
            }
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<HotelGroupSecurity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<HotelGroupSecurity> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(HotelGroupSecurity entity)
        {
            throw new NotImplementedException();
        }
    }
}

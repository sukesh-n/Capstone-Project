using HotelBookingApp.Context;
using HotelBookingApp.Interface.IRepository.IHotels.IHotelGroups;
using HotelBookingApp.Models.Hotels.HotelGroups;

namespace HotelBookingApp.Repositories.HotelsRepository.HotelGroupsRepository
{
    public class HotelGroupRepository : IHotelGroupRepository
    {
        public readonly HotelBookingDbContext _context;

        public HotelGroupRepository(HotelBookingDbContext context)
        {
            _context = context;
        }

        public async Task<HotelGroup> AddAsync(HotelGroup enitity)
        {
            try
            {
                var accountCreation = await _context.HotelGroups.AddAsync(enitity);
                await _context.SaveChangesAsync();
                if (accountCreation == null)
                {
                    throw new ErrorInConnectingRepository("Error: Group Account not created");
                }
                return accountCreation.Entity;
            }
            catch (Exception ex)
            {
                throw new ErrorInConnectingRepository($"Error: {ex.Message}");
            }
        }

        public Task DeleteAsync(int id)
        {
            try
            {
                var deleteGroup = _context.HotelGroups.Find(id);
                if (deleteGroup == null)
                {
                    throw new ErrorInConnectingRepository("Error: Group Account not found");
                }
                _context.HotelGroups.Remove(deleteGroup);
                return _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ErrorInConnectingRepository($"Error: {ex.Message}");
            }
        }

        public Task<IEnumerable<HotelGroup>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<HotelGroup> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(HotelGroup entity)
        {
            throw new NotImplementedException();
        }
    }
}

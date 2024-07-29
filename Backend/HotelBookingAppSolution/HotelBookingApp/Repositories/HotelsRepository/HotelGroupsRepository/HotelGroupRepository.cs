using HotelBookingApp.Context;
using HotelBookingApp.Exceptions;
using HotelBookingApp.Interface.IRepository.IHotels.IHotelGroups;
using HotelBookingApp.Models.Hotels.HotelGroups;
using Microsoft.EntityFrameworkCore;

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
                    throw new ErrorInConnectingRepositoryException("Error: Group Account not created");
                }
                return accountCreation.Entity;
            }
            catch (Exception ex)
            {
                throw new ErrorInConnectingRepositoryException($"Error: {ex.Message}");
            }
        }

        public Task<bool> DeleteAsync(int id)
        {
            try
            {
                var deleteGroup = _context.HotelGroups.Find(id);
                if (deleteGroup == null)
                {
                    throw new ErrorInConnectingRepositoryException("Error: Group Account not found");
                }
                _context.HotelGroups.Remove(deleteGroup);
                _context.SaveChangesAsync();
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new ErrorInConnectingRepositoryException($"Error: {ex.Message}");
            }
        }

        public Task<IEnumerable<HotelGroup>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<HotelGroup> GetByIdAsync(int id)
        {
            try
            {
                var result = await _context.HotelGroups.FirstOrDefaultAsync(x => x.HotelGroupId == id);
                if (result == null)
                {
                    throw new ErrorInConnectingRepositoryException("Error: Group Account not found");
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new ErrorInConnectingRepositoryException($"Error: {ex.Message}");
            }
        }

        public async Task<HotelGroup?> GetHotelGroupByEmail(string Email)
        {
            try
            {
                var getGroup = await _context.HotelGroups.FirstOrDefaultAsync(x => x.HotelGroupEmail == Email);
                if (getGroup == null)
                {
                    return null;
                }
                return getGroup;
            }
            catch (Exception ex)
            {
                throw new ErrorInConnectingRepositoryException($"Error: {ex.Message}");
            }
        }

        public Task<HotelGroup> UpdateAsync(HotelGroup entity)
        {
            throw new NotImplementedException();
        }
    }
}

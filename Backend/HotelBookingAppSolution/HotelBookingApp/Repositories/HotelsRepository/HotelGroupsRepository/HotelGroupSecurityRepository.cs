using HotelBookingApp.Context;
using HotelBookingApp.Exceptions;
using HotelBookingApp.Interface.IRepository.IHotels.IHotelGroups;
using HotelBookingApp.Models.Hotels.HotelGroups;
using Microsoft.EntityFrameworkCore;

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
                await _context.SaveChangesAsync();
                if (AddSecurity == null)
                {
                    throw new ErrorInConnectingRepositoryException("Error: Security not added");
                }
                return AddSecurity.Entity;
            }
            catch (Exception ex)
            {
                throw new ErrorInConnectingRepositoryException($"Error: {ex.Message}");
            }
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<HotelGroupSecurity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<HotelGroupSecurity> GetByIdAsync(int id)
        {
            try
            {
                var getSecurity = await _context.HotelGroupSecurities
                                                 .FirstOrDefaultAsync(h => h.HotelGroupId == id);
                if (getSecurity == null)
                {
                    return new HotelGroupSecurity
                    {HotelGroupId=-1};
                }
                return getSecurity;
            }
            catch (Exception ex)
            {
                throw new ErrorInConnectingRepositoryException($"Error: {ex.Message}");
            }
        }


        public async Task<HotelGroupSecurity> UpdateAsync(HotelGroupSecurity entity)
        {
            try
            {
                _context.HotelGroupSecurities.Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new ErrorInConnectingRepositoryException($"Error: {ex.Message}", ex);
            }
        }

    }
}

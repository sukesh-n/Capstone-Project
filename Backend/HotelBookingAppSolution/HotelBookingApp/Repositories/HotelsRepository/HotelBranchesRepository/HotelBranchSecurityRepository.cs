using HotelBookingApp.Context;
using HotelBookingApp.Exceptions;
using HotelBookingApp.Interface.IRepository.IHotels.IHotelBranches;
using HotelBookingApp.Models.Hotels.HotelBranches;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Repositories.HotelsRepository.HotelBranchesRepository
{
    public class HotelBranchSecurityRepository : IHotelBranchSecurityRepository
    {
        public readonly HotelBookingDbContext _context;

        public HotelBranchSecurityRepository(HotelBookingDbContext context)
        {
            _context = context;
        }

        public async Task<HotelBranchSecurity> AddAsync(HotelBranchSecurity enitity)
        {
            try
            {
                var AddSecurity = await _context.HotelBranchSecurities.AddAsync(enitity);
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

        public Task<IEnumerable<HotelBranchSecurity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<HotelBranchSecurity> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<HotelBranchSecurity> GetSecurityByBranchId(int BranchId)
        {
            try
            {
                var getSecurity = await _context.HotelBranchSecurities
                                                 .FirstOrDefaultAsync(h => h.HotelBranchId == BranchId);

                if (getSecurity == null)
                {
                    return new HotelBranchSecurity
                    {
                        HotelBranchId = -1
                    };
                }
                return getSecurity;
            }
            catch (Exception ex)
            {
                throw new ErrorInConnectingRepositoryException($"Error: {ex.Message}");
            }
        }

        public async Task<HotelBranchSecurity> UpdateAsync(HotelBranchSecurity entity)
        {
            try
            {
                var updateSecurity = await _context.HotelBranchSecurities
                                                    .FirstOrDefaultAsync(h => h.HotelBranchId == entity.HotelBranchId);
                if (updateSecurity == null)
                {
                    updateSecurity = await AddAsync(entity);
                }
                return updateSecurity;
            }
            catch (Exception ex)
            {
                throw new ErrorInConnectingRepositoryException($"Error: {ex.Message}");
            }
        }
    }
}

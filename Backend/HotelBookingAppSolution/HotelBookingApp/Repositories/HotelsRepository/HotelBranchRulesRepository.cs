using HotelBookingApp.Context;
using HotelBookingApp.Exceptions;
using HotelBookingApp.Interface.IRepository.IHotels;
using HotelBookingApp.Models.Hotels;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Repositories.HotelsRepository
{
    public class HotelBranchRulesRepository : IHotelBranchRulesRepository
    {
        public readonly HotelBookingDbContext _context;

        public HotelBranchRulesRepository(HotelBookingDbContext context)
        {
            _context = context;
        }

        public async Task<HotelBranchRules> AddAsync(HotelBranchRules enitity)
        {
            try
            {
                var AddBranchRules = await _context.HotelBranchRules.AddAsync(enitity);
                await _context.SaveChangesAsync();
                if (AddBranchRules == null)
                {
                    throw new ErrorInConnectingRepositoryException("Error: Branch Rules not added");
                }
                return AddBranchRules.Entity;
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

        public Task<IEnumerable<HotelBranchRules>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<HotelBranchRules> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<HotelBranchRules> UpdateAsync(HotelBranchRules entity)
        {
            try
            {
                var ExistenceCheck = await _context.HotelBranchRules.FindAsync(entity.HotelBranchId);
                var BranchRulesUpdate = new HotelBranchRules();
                if(ExistenceCheck == null)
                {
                    BranchRulesUpdate = await AddAsync(entity);
                }
                else
                {
                    BranchRulesUpdate = _context.HotelBranchRules.Update(entity).Entity;
                    await _context.SaveChangesAsync();
                }
                return BranchRulesUpdate;
            }
            catch (Exception ex)
            {
                throw new ErrorInConnectingRepositoryException($"Error: {ex.Message}");
            }
        }
    }
}

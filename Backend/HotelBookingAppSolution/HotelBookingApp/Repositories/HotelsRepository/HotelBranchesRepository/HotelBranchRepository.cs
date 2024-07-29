using HotelBookingApp.Context;
using HotelBookingApp.Exceptions;
using HotelBookingApp.Interface.IRepository.IHotels.IHotelBranches;
using HotelBookingApp.Models.Hotels.HotelBranches;
using HotelBookingApp.Repositories.HotelsRepository.HotelGroupsRepository;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Repositories.HotelsRepository.HotelBranchesRepository
{
    public class HotelBranchRepository : IHotelBranchRepository
    {
        private readonly HotelBookingDbContext _context;

        public HotelBranchRepository(HotelBookingDbContext context)
        {
            _context = context;
        }

        public async Task<HotelBranch> AddAsync(HotelBranch enitity)
        {
            try
            {
                var hotelBranch = await _context.HotelBranches.AddAsync(enitity);
                await _context.SaveChangesAsync();
                if (hotelBranch == null)
                {
                    throw new ErrorInConnectingRepositoryException("Error: Hotel Branch not created");
                }
                return hotelBranch.Entity;
            }
            catch (Exception ex)
            {
                throw new ErrorInConnectingRepositoryException($"Error: {ex.Message}", ex);
            }
        }


        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var DeleteHotelBranch = await _context.HotelBranches.FindAsync(id);
                if (DeleteHotelBranch == null)
                {
                    throw new KeyNotFoundException($"HotelBranch with ID {id} not found.");
                }
                _context.HotelBranches.Remove(DeleteHotelBranch);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new ErrorInConnectingRepositoryException($"Error: {ex.Message}", ex);
            }
        }

        public Task<IEnumerable<HotelBranch>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<HotelBranch> GetByIdAsync(int id)
        {
            try
            {
                var hotelBranch = await _context.HotelBranches
                                                .FirstOrDefaultAsync(h => h.HotelBranchId == id);
                if (hotelBranch == null)
                {
                    return new HotelBranch
                    {
                        HotelBranchId = -1
                    };
                }
                return hotelBranch;
            }
            catch (Exception ex)
            {
                throw new ErrorInConnectingRepositoryException($"Error: {ex.Message}", ex);
            }
        }

        public async Task<HotelBranch?> GetHotelBranchByEmail(string email)
        {
            try
            {
                var hotelBranch = await _context.HotelBranches
                                                .FirstOrDefaultAsync(h => h.HotelBranchEmail == email);
                return hotelBranch;
            }
            catch (Exception ex)
            {
                throw new ErrorInConnectingRepositoryException($"Error: {ex.Message}", ex);
            }
        }

        public async Task<List<HotelBranch>?> GetHotelBranchesByGroupId(int HotelGroupId)
        {
            try
            {
                var getAllBranches = await _context.HotelBranches
                                                .Where(h => h.HotelGroupId == HotelGroupId)
                                                .ToListAsync();
                return getAllBranches;
            }
            catch (Exception ex)
            {
                throw new ErrorInConnectingRepositoryException($"Error: {ex.Message}", ex);
            }
        }

        public Task<HotelBranch> UpdateAsync(HotelBranch entity)
        {
            throw new NotImplementedException();
        }
    }
}
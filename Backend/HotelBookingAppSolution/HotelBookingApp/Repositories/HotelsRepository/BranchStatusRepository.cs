using HotelBookingApp.Context;
using HotelBookingApp.Exceptions;
using HotelBookingApp.Interface.IRepository.IHotels;
using HotelBookingApp.Models.Hotels;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Repositories.HotelsRepository
{
    public class BranchStatusRepository : IBranchStatusRepository
    {
        public readonly HotelBookingDbContext _context;

        public BranchStatusRepository(HotelBookingDbContext context)
        {
            _context = context;
        }

        public async Task<BranchStatus> AddNewBranchStatus(BranchStatus branchStatus)
        {
            try
            {
                var addStatus = await _context.BranchStatuses.AddAsync(branchStatus);
                await _context.SaveChangesAsync();
                return addStatus.Entity;
            }
            catch
            {
                throw new ErrorInConnectingRepositoryException("Error in adding branch status");
            }
        }

        public async Task<BranchStatus?> GetBranchStatus(int BranchId)
        {
            try
            {
                var branchStatus = await _context.BranchStatuses.Where(e=>e.HotelBranchId==BranchId).FirstOrDefaultAsync();
                if (branchStatus == null)
                {
                    return null;
                }
                return branchStatus;
            }
            catch
            {
                throw new ErrorInConnectingRepositoryException("Error in getting branch status");
            }
        }

        public async Task<BranchStatus> UpdateBranchStatus(BranchStatus branchStatus)
        {
            try
            {
                var existingBranchStatus = await _context.BranchStatuses
                    .FirstOrDefaultAsync(bs => bs.HotelBranchId == branchStatus.HotelBranchId);

                if (existingBranchStatus == null)
                {
                    _context.BranchStatuses.Add(branchStatus);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    _context.Entry(existingBranchStatus).CurrentValues.SetValues(branchStatus);
                    await _context.SaveChangesAsync();
                }

                return branchStatus;
            }
            catch (Exception ex)
            {
                throw new ErrorInConnectingRepositoryException("Error in updating branch status", ex);
            }
        }

    }
}

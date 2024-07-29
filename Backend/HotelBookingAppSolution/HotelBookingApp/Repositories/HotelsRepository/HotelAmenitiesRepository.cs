using HotelBookingApp.Context;
using HotelBookingApp.Exceptions;
using HotelBookingApp.Interface.IRepository.IHotels;
using HotelBookingApp.Models.Hotels;

namespace HotelBookingApp.Repositories.HotelsRepository
{
    public class HotelAmenitiesRepository : IHotelAmenitiesRepository
    {
        public readonly HotelBookingDbContext _context;

        public HotelAmenitiesRepository(HotelBookingDbContext context)
        {
            _context = context;
        }

        public async Task<HotelAmenities> AddAsync(HotelAmenities enitity)
        {
            try
            {
                var AddAmenities = await _context.HotelAmenities.AddAsync(enitity);
                await _context.SaveChangesAsync();
                if (AddAmenities == null)
                {
                    throw new ErrorInConnectingRepositoryException("Error: Amenities not added");
                }
                return AddAmenities.Entity;
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

        public Task<IEnumerable<HotelAmenities>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<HotelAmenities> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<HotelAmenities> UpdateAsync(HotelAmenities entity)
        {
            try
            {
                var ExistenceCheck = await _context.HotelAmenities.FindAsync(entity.HotelBranchId);
                var BranchRulesUpdate = new HotelAmenities();
                if(ExistenceCheck == null)
                {
                    BranchRulesUpdate = await AddAsync(entity);
                }
                else
                {
                    _context.HotelAmenities.Update(entity);
                    await _context.SaveChangesAsync();
                    BranchRulesUpdate = entity;
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

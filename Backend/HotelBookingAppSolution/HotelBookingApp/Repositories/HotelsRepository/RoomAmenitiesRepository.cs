using HotelBookingApp.Context;
using HotelBookingApp.Exceptions;
using HotelBookingApp.Interface.IRepository.IHotels;
using HotelBookingApp.Models.Hotels;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Repositories.HotelsRepository
{
    public class RoomAmenitiesRepository : IRoomAmenitiesRepository
    {
        public readonly HotelBookingDbContext _context;

        public RoomAmenitiesRepository(HotelBookingDbContext context)
        {
            _context = context;
        }

        public async Task<RoomAmenities> AddAsync(RoomAmenities enitity)
        {
            try
            {
                var roomAmenities = await _context.RoomAmenities.AddAsync(enitity);
                await _context.SaveChangesAsync();
                if (roomAmenities == null)
                {
                    throw new ErrorInConnectingRepositoryException("Error: Room Amenities not added");
                }
                return roomAmenities.Entity;
            }
            catch (Exception e)
            {
                throw new ErrorInConnectingRepositoryException($"Error: {e.Message}");
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var DeleteRoomAmenities = _context.RoomAmenities
                    .FirstOrDefault(r => r.RoomTypeId == id);
                if (DeleteRoomAmenities == null)
                {
                    throw new KeyNotFoundException($"RoomAmenities with ID {id} not found.");
                }
                var Delete= _context.RoomAmenities.Remove(DeleteRoomAmenities);
                await _context.SaveChangesAsync();                
                return true;
            }
            catch (Exception e)
            {
                throw new ErrorInConnectingRepositoryException($"Error: {e.Message}");
            }
        }

        public Task<IEnumerable<RoomAmenities>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<RoomAmenities> GetByBranchAndAmenity(int BranchId, int RoomTypeId)
        {
            try
            {
                var roomAmenities = await _context.RoomAmenities
                    .FirstOrDefaultAsync(r => r.HotelBranchId == BranchId && r.RoomTypeId == RoomTypeId);
                if (roomAmenities == null)
                {
                    return new RoomAmenities();
                }
                return roomAmenities;
            }
            catch (Exception e)
            {
                throw new ErrorInConnectingRepositoryException("Error in Amenities Repository",e);
            }
        }

        public Task<RoomAmenities> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<RoomAmenities> UpdateAsync(RoomAmenities entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "The entity cannot be null.");
            }

            try
            {
                var existingRoomAmenities = await _context.RoomAmenities
                    .FirstOrDefaultAsync(r => r.HotelBranchId== entity.HotelBranchId);

                if (existingRoomAmenities == null)
                {
                    var addRoomAmenities = await _context.RoomAmenities.AddAsync(entity);
                    await _context.SaveChangesAsync();
                    return addRoomAmenities.Entity;
                }
                _context.Entry(existingRoomAmenities).CurrentValues.SetValues(entity);

                await _context.SaveChangesAsync();

                return existingRoomAmenities;
            }
            catch (Exception e)
            {
                throw new ErrorInConnectingRepositoryException($"Error: {e.Message}", e);
            }
        }
    }
}
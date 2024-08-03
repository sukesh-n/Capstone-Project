using HotelBookingApp.Context;
using HotelBookingApp.Exceptions;
using HotelBookingApp.Interface.IRepository.IHotels;
using HotelBookingApp.Models.Hotels;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Repositories.HotelsRepository
{
    public class RoomTypeRepository : IRoomTypeRepository
    {
        private readonly HotelBookingDbContext _context;

        public RoomTypeRepository(HotelBookingDbContext context)
        {
            _context = context;
        }

        public async Task<RoomType> AddAsync(RoomType enitity)
        {
            try
            {
                var result = await _context.RoomTypes.AddAsync(enitity);
                await _context.SaveChangesAsync();
                if (result == null)
                {
                    throw new ErrorInConnectingRepositoryException("Error: Room Type not added");
                }
                return result.Entity;
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
                var DeleteRoomType = await _context.RoomTypes
                    .FirstOrDefaultAsync(r => r.RoomTypeId == id);
                if (DeleteRoomType == null)
                {
                    throw new KeyNotFoundException($"RoomType with ID {id} not found.");
                }
                _context.RoomTypes.Remove(DeleteRoomType);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw new ErrorInConnectingRepositoryException($"Error: {e.Message}");
            }
        }

        public Task<IEnumerable<RoomType>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<RoomType> GetByBranchAndRoomType(int BranchId, EnumRoomTypes EnumRoomTypeId)
        {
            try
            {
                var roomType = await _context.RoomTypes
                    .FirstOrDefaultAsync(r => r.RoomTypeName == EnumRoomTypeId && r.HotelBranchId == BranchId);
                if (roomType == null)
                {
                    return new RoomType();
                }
                return roomType;
            }
            catch (Exception e)
            {
                throw new ErrorInConnectingRepositoryException("Error in Repository",e);
            }
        }

        public Task<RoomType> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RoomType>?> GetRoomTypesByBranchId(int BranchId)
        {
            try
            {
                var roomTypes = await _context.RoomTypes
                    .Where(r => r.HotelBranchId == BranchId)
                    .ToListAsync();
                if (roomTypes == null)
                {
                    return null;
                }
                return roomTypes;
            }
            catch (Exception e)
            {
                throw new ErrorInConnectingRepositoryException("Error in Repository", e);
            }
        }

        public async Task<RoomType> UpdateAsync(RoomType entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "The entity cannot be null.");
            }

            try
            {
                var existingRoomType = await _context.RoomTypes
                    .FirstOrDefaultAsync(r => r.RoomTypeId == entity.RoomTypeId);

                if (existingRoomType == null)
                {
                    throw new KeyNotFoundException($"RoomType with ID {entity.RoomTypeId} not found.");
                }

                existingRoomType.RoomTypeName = entity.RoomTypeName;

                await _context.SaveChangesAsync();

                return existingRoomType;
            }
            catch (Exception e)
            {
                throw new ErrorInConnectingRepositoryException($"Error: {e.Message}", e);
            }
        }

    }
}
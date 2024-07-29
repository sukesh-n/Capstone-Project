using HotelBookingApp.Context;
using HotelBookingApp.Exceptions;
using HotelBookingApp.Interface.IRepository.IHotels;
using HotelBookingApp.Models.Hotels;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Repositories.HotelsRepository
{
    public class HotelDemographicsRepository : IHotelDemographicsRepository
    {
        public readonly HotelBookingDbContext _context;

        public HotelDemographicsRepository(HotelBookingDbContext context)
        {
            _context = context;
        }

        public async Task<HotelDemographics> AddAsync(HotelDemographics enitity)
        {
            try
            {
                var result = await _context.HotelDemographics.AddAsync(enitity);
                await _context.SaveChangesAsync();
                if(result == null)
                {
                    throw new ErrorInConnectingRepositoryException("Error: Demography not added");
                }
                return result.Entity;
            }
            catch(Exception ex)
            {
                throw new ErrorInConnectingRepositoryException("Unable to add Demography", ex);
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var RemoveDemography = await _context.HotelDemographics.FirstOrDefaultAsync(h => h.HotelId == id);
                if (RemoveDemography == null)
                {
                    return false;
                }
                _context.HotelDemographics.Remove(RemoveDemography);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new ErrorInConnectingRepositoryException("Unable to delete Demography", ex);
            }
        }

        public async Task<IEnumerable<HotelDemographics>> GetAllAsync()
        {
            try
            {
                var AllDemography = await _context.HotelDemographics.ToListAsync();
                if (AllDemography == null)
                {
                    return new List<HotelDemographics>();
                }
                return AllDemography;
            }
            catch (Exception ex)
            {
                throw new ErrorInConnectingRepositoryException("Unable to get Demography", ex);
            }
        }

        public async Task<HotelDemographics> GetByIdAsync(int id)
        {
            try
            {
                var result = await _context.HotelDemographics.FirstOrDefaultAsync(h => h.HotelId == id);
                if (result == null)
                {
                    return new HotelDemographics
                    {
                        HotelId = -1
                    };
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new ErrorInConnectingRepositoryException("Unable to get Demography", ex);
            }
        }

        public async Task<HotelDemographics> UpdateAsync(HotelDemographics entity)
        {
            try
            {
                var CheckExistence = await _context.HotelDemographics.FirstOrDefaultAsync(h => h.HotelId == entity.HotelId);
                var result = new HotelDemographics();
                if (CheckExistence == null)
                {
                    result = await AddAsync(entity);
                }
                else
                {
                    result = _context.HotelDemographics.Update(entity).Entity;
                    await _context.SaveChangesAsync();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new ErrorInConnectingRepositoryException("Unable to update Demography", ex);
            }
        }
    }
}

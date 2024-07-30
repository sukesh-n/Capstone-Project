using HotelBookingApp.Context;
using HotelBookingApp.Exceptions;
using HotelBookingApp.Interface.IRepository.IGuest.IGuests;
using HotelBookingApp.Models.Guests;

namespace HotelBookingApp.Repositories.GuestsRepository
{
    public class GuestDemographicsRepository : IGuestDemographicsRepository
    {
        private readonly HotelBookingDbContext _context;

        public GuestDemographicsRepository(HotelBookingDbContext context)
        {
            _context = context;
        }

        public async Task<GuestDemographics> AddAsync(GuestDemographics enitity)
        {
            try
            {
                var AddGuestDemographics = await _context.GuestDemographics.AddAsync(enitity);
                await _context.SaveChangesAsync();
                if (AddGuestDemographics.Entity == null)
                {
                    throw new ErrorInConnectingRepositoryException("Error in connecting to the repository");
                }
                return AddGuestDemographics.Entity;

            }
            catch (System.Exception ex)
            {
                throw new ErrorInConnectingRepositoryException("Error in connecting to the repository", ex);
            }
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GuestDemographics>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<GuestDemographics> GetByIdAsync(int GuestId)
        {
            try
            {
                var GetGuestDemographics = await _context.GuestDemographics.FindAsync(GuestId);
                if (GetGuestDemographics == null)
                {
                    throw new ErrorInConnectingRepositoryException("Error in connecting to the repository");
                }
                return GetGuestDemographics;
            }
            catch (System.Exception ex)
            {
                throw new ErrorInConnectingRepositoryException("Error in connecting to the repository", ex);
            }
        }

        public async Task<GuestDemographics> UpdateAsync(GuestDemographics entity)
        {
            try
            {
                var UpdateGuestDemographics = await _context.GuestDemographics.FindAsync(entity.GuestId);
                if (UpdateGuestDemographics == null)
                {
                    throw new ErrorInConnectingRepositoryException("Error in connecting to the repository");
                }
                _context.Entry(UpdateGuestDemographics).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
                return UpdateGuestDemographics;

            }
            catch (System.Exception ex)
            {
                throw new ErrorInConnectingRepositoryException("Error in connecting to the repository", ex);
            }
        }
    }
}

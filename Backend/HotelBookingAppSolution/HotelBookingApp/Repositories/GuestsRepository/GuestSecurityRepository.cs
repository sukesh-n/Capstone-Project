using HotelBookingApp.Context;
using HotelBookingApp.Exceptions;
using HotelBookingApp.Interface.IRepository.IGuest.IGuests;
using HotelBookingApp.Models.Guests;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HotelBookingApp.Repositories.GuestsRepository
{
    public class GuestSecurityRepository : IGuestSecurityRepository
    {
        public HotelBookingDbContext _context;

        public GuestSecurityRepository(HotelBookingDbContext context)
        {
            _context = context;
        }

        public async Task<GuestSecurity> AddAsync(GuestSecurity enitity)
        {
            try
            {
                var AddGuestSecurity = await _context.GuestSecurities.AddAsync(enitity);
                await _context.SaveChangesAsync();
                if (AddGuestSecurity.Entity == null)
                {
                    throw new ErrorInConnectingRepositoryException("Error in connecting to the repository");
                }
                return AddGuestSecurity.Entity;
            }
            catch (Exception ex)
            {
                throw new ErrorInConnectingRepositoryException("Error in connecting to the repository", ex);
            }

        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var DeleteGuestSecurity = await _context.GuestSecurities.FirstOrDefaultAsync(x => x.GuestId == id);
                if (DeleteGuestSecurity == null)
                {
                    throw new ErrorInConnectingRepositoryException("Error in connecting to the repository");
                }
                _context.GuestSecurities.Remove(DeleteGuestSecurity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new ErrorInConnectingRepositoryException("Error in connecting to the repository", ex);
            }
        }

        public Task<IEnumerable<GuestSecurity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<GuestSecurity> GetByIdAsync(int id)
        {
            try
            {
                var GetGuestSecurity = await _context.GuestSecurities.FirstOrDefaultAsync(x => x.GuestId == id);
                if (GetGuestSecurity == null)
                {
                    throw new EmptyDataException("Error in connecting to the repository");
                }
                return GetGuestSecurity;
            }
            catch (Exception ex)
            {
                throw new ErrorInConnectingRepositoryException("Error in connecting to the repository", ex);
            }
        }

        public async Task<GuestSecurity> UpdateAsync(GuestSecurity entity)
        {
            try
            {
                var UpdateGuestSecurity = await _context.GuestSecurities.FirstOrDefaultAsync(x => x.GuestId == entity.GuestId);
                if (UpdateGuestSecurity == null)
                {
                    var AddGuestSecurity = await _context.GuestSecurities.AddAsync(entity);
                    await _context.SaveChangesAsync();
                    if (AddGuestSecurity.Entity == null)
                    {
                        throw new ErrorInConnectingRepositoryException("Error in connecting to the repository");
                    }
                    return AddGuestSecurity.Entity;
                }

                var NewSecurity = new GuestSecurity
                {
                    GuestPassword = entity.GuestPassword,
                    GuestPasswordHashKey = entity.GuestPasswordHashKey
                };
                _context.Entry(UpdateGuestSecurity).CurrentValues.SetValues(NewSecurity);
                await _context.SaveChangesAsync();
                return UpdateGuestSecurity;
            }
            catch (Exception ex)
            {
                throw new ErrorInConnectingRepositoryException("Error in connecting to the repository", ex);
            }
        }
    }
}

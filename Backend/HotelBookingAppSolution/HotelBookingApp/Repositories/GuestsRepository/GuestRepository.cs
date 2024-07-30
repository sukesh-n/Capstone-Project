using HotelBookingApp.Context;
using HotelBookingApp.Exceptions;
using HotelBookingApp.Interface.IRepository.IGuests;
using HotelBookingApp.Models.Guests;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Repositories.GuestsRepository
{
    public class GuestRepository : IGuestRepository
    {
        public HotelBookingDbContext _context;

        public GuestRepository(HotelBookingDbContext context)
        {
            _context = context;
        }

        public async Task<Guest> AddAsync(Guest enitity)
        {
            try
            {
                var AddGuest = await _context.Guests.AddAsync(enitity);
                await _context.SaveChangesAsync();
                if(AddGuest.Entity == null)
                {
                    throw new ErrorInConnectingRepositoryException("Error in connecting to the repository");
                }
                return AddGuest.Entity;
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
                var DeleteGuest = await _context.Guests.FirstOrDefaultAsync(x => x.GuestId == id);
                if (DeleteGuest == null)
                {
                    throw new ErrorInConnectingRepositoryException("Error in connecting to the repository");
                }
                _context.Guests.Remove(DeleteGuest);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                throw new ErrorInConnectingRepositoryException("Error in connecting to the repository", ex);
            }
        }

        public async Task<IEnumerable<Guest>> GetAllAsync()
        {
            try
            {
                var GetAllGuests = await _context.Guests.ToListAsync();
                if (GetAllGuests == null)
                {
                    throw new EmptyDataException("Error in connecting to the repository");
                }
                return GetAllGuests;
            }
            catch (Exception ex)
            {
                throw new ErrorInConnectingRepositoryException("Error in connecting to the repository", ex);
            }
        }

        public async Task<Guest> GetByIdAsync(int id)
        {
            try
            {
                var GetGuest = await _context.Guests.FirstOrDefaultAsync(x => x.GuestId == id);
                if (GetGuest == null)
                {
                    throw new ErrorInConnectingRepositoryException("Error in connecting to the repository");
                }
                return GetGuest;
            }
            catch (Exception ex)
            {
                throw new ErrorInConnectingRepositoryException("Error in connecting to the repository", ex);
            }
        }

        public async Task<Guest?> GetGuestByEmail(string email)
        {
            try
            {
                var guest = await _context.Guests.FirstOrDefaultAsync(x => x.GuestEmail == email);
                if (guest == null)
                {
                    return null;
                }
                return guest;
            }
            catch
            {
                throw new ErrorInConnectingRepositoryException("Error in connecting to the repository");
            }
        }

        public async Task<Guest> UpdateAsync(Guest entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity is null");
            }

            try
            {
                // Retrieve the existing guest
                var existingGuest = await _context.Guests.FindAsync(entity.GuestId);
                if (existingGuest == null)
                {
                    throw new KeyNotFoundException("Guest not found");
                }

                // Check for duplicate email if changed
                if (entity.GuestEmail != existingGuest.GuestEmail)
                {
                    var duplicateGuest = await GetGuestByEmail(entity.GuestEmail);
                    if (duplicateGuest != null)
                    {
                        throw new InvalidOperationException("A guest with this email already exists");
                    }
                }

                // Update the existing guest's properties
                existingGuest.GuestEmail = entity.GuestEmail;
                existingGuest.GuestName = entity.GuestName;
                existingGuest.GuestPhone = entity.GuestPhone;

                // Save changes
                _context.Guests.Update(existingGuest);
                await _context.SaveChangesAsync();

                return existingGuest;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while updating the guest", ex);
            }
        }

    }
}

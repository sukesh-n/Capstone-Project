using HotelBookingApp.Models.Admins;
using HotelBookingApp.Models.Guests;
using HotelBookingApp.Models.Hotels.HotelBranches;
using HotelBookingApp.Models.Hotels.HotelGroups;

namespace HotelBookingApp.Interface.IToken
{
    public interface ITokenService
    {
        public string GenerateGuestToken(Guest guest);
        public string GenerateAdminToken(Admin admin);
        public string GenerateHotelBranchToken(HotelBranch hotelBranch);
        public string GenerateHotelGroupToken(HotelGroup hotelGroup);
    }
}

using HotelBookingApp.Interface.IToken;
using HotelBookingApp.Models.Admins;
using HotelBookingApp.Models.Guests;
using HotelBookingApp.Models.Hotels.HotelBranches;
using HotelBookingApp.Models.Hotels.HotelGroups;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HotelBookingApp.Token
{
    public class TokenService : ITokenService
    {
        private readonly string _SecretKey;
        private readonly SymmetricSecurityKey _key;

        public TokenService(IConfiguration configuration)
        {
            _SecretKey = configuration.GetSection("TokenKey").GetSection("JWT").Value.ToString();
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_SecretKey));
        }
        public string GenerateAdminToken(Admin admin)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, admin.AdminEmail),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("adminId", admin.AdminId.ToString()),
                new Claim(ClaimTypes.Role, "admin"),
                new Claim(ClaimTypes.Name, admin.AdminName)

            };
            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateGuestToken(Guest guest)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, guest.GuestEmail),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("guestId", guest.GuestId.ToString()),
                new Claim(ClaimTypes.Role, "guest"),
                new Claim(ClaimTypes.Name, guest.GuestName)

            };
            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateHotelBranchToken(HotelBranch hotelBranch)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, hotelBranch.HotelBranchEmail),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("hotelBranchId", hotelBranch.HotelBranchId.ToString()),
                new Claim(ClaimTypes.Role, "hotelBranch"),
                new Claim(ClaimTypes.Name, hotelBranch.HotelBranchName)

            };
            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateHotelGroupToken(HotelGroup hotelGroup)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, hotelGroup.HotelGroupEmail),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("hotelGroupId", hotelGroup.HotelGroupId.ToString()),
                new Claim(ClaimTypes.Role, "hotelGroup"),
                new Claim(ClaimTypes.Name, hotelGroup.HotelGroupName)

            };
            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

using System.Security.Cryptography;
using System.Text;

namespace HotelBookingApp.Services.Hashing
{
    public class Password
    {
        public (byte[] PasswordByte, byte[] PasswordHashKey_) PasswordHashing(string Password)
        {
            HMACSHA512 hMACSHA512 = new HMACSHA512();
            var PasswordBytesHash = hMACSHA512.ComputeHash(ConvertToByte(Password));
            var key = hMACSHA512.Key;
            return (PasswordBytesHash, key);
        }
        public byte[] ConvertToByte(string Password)
        {
            return Encoding.UTF8.GetBytes(Password);
        }
        public bool ComparePassword(string password, byte[] storedPassword, byte[] key)
        {
            using (var hmac = new HMACSHA512(key))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedPassword[i]) return false;
                }
            }
            return true;
        }
    }
}

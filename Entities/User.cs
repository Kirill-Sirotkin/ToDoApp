using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace ToDoApp.Entities
{
    public class User
    {
        public Guid _userId {get; private set;}
        public string _email {get; private set;}
        public string _passwordHash {get; private set;}
        public byte[] _salt {get; private set;}
        public DateTimeOffset _createdTimestamp {get; private set;}
        public DateTimeOffset _updatedTimestamp {get; private set;}

        public User(string email, string password)
        {
            _email = email;
            _salt = GetSalt();
            _passwordHash = GetHashedPassword(password, _salt);

            _userId = Guid.NewGuid();
            _createdTimestamp = DateTimeOffset.UtcNow;
            _updatedTimestamp = _createdTimestamp;
        }
        
        public static byte[] GetSalt()
        {
            return RandomNumberGenerator.GetBytes(128 / 8);
        }
        public static string GetHashedPassword(string password, byte[] salt)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password,
                salt,
                KeyDerivationPrf.HMACSHA256,
                10000,
                256 / 8
            ));
        }
        public void UpdatePassword(string password)
        {
            _passwordHash = GetHashedPassword(password, _salt);
            _updatedTimestamp = DateTimeOffset.UtcNow;
        }
    }
}
using System.Security.Cryptography;
using System.Text;
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
        
        public static string ConvertSaltToString(byte[] salt)
        {
            return Encoding.UTF8.GetString(salt);
        }
        public static byte[] ConvertSaltToByteArray(string salt)
        {
            return Encoding.UTF8.GetBytes(salt);
        }
        public static byte[] GetSalt()
        {
            byte[] array = RandomNumberGenerator.GetBytes(128 / 8);
            string arrayToString = ConvertSaltToString(array);

            return ConvertSaltToByteArray(arrayToString);
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
        public static UserDatabaseModel ConvertToDatabaseModel(User user)
        {
            return 
            new UserDatabaseModel
            {
                Id = user._userId,
                _email = user._email,
                _passwordHash = user._passwordHash,
                _salt = User.ConvertSaltToString(user._salt),
                _createdTimestamp = user._createdTimestamp,
                _updatedTimestamp = user._updatedTimestamp
            };
        }
        public void UpdatePassword(string password)
        {
            _passwordHash = GetHashedPassword(password, _salt);
            _updatedTimestamp = DateTimeOffset.UtcNow;
        }
    }
}
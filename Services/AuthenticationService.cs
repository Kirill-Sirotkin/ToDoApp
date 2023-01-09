using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ToDoApp.Entities;
using ToDoApp.Repositories;

namespace ToDoApp.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly DataBaseContext _database;
        private readonly Settings _settings;

        public AuthenticationService(Settings settings, DataBaseContext database)
        {
            _database = database;
            _settings = settings;
        }

        public (bool success, string content) SignUp(string email, string password)
        {
            if (_database.Users.Any(u => u._email == email)) { return (false, "Email already in use"); }

            User user = new User(email, password);
            UserDatabaseModel userDb = User.ConvertToDatabaseModel(user);

            _database.Add(userDb);
            _database.SaveChanges();

            return (true, "");
        }
        public (bool success, string token) SignIn(string email, string password)
        {
            UserDatabaseModel userDb = _database.Users.SingleOrDefault(u => u._email == email);

            if (userDb == null) 
            { return (false, "Invalid email"); }

            if (userDb._passwordHash != User.GetHashedPassword(password, User.ConvertSaltToByteArray(userDb._salt))) 
            { return (false, "Wrong password"); }

            return (true, GenerateJWToken(GenerateClaimsIdentity(userDb)));
        }
        public (bool success, string content) ChangePassword(Guid userId, string oldPassword, string newPassword)
        {
            UserDatabaseModel userDb = _database.Users.SingleOrDefault(u => u.Id == userId);

            if (userDb == null) 
            { return (false, "User not found"); }

            if (userDb._passwordHash != User.GetHashedPassword(oldPassword, User.ConvertSaltToByteArray(userDb._salt))) 
            { return (false, "Wrong old password"); }

            userDb._passwordHash = User.GetHashedPassword(newPassword, User.ConvertSaltToByteArray(userDb._salt));
            userDb._updatedTimestamp = DateTimeOffset.UtcNow;
            _database.SaveChanges();

            return (true, "Password changed successfully");
        }

        private ClaimsIdentity GenerateClaimsIdentity(UserDatabaseModel user)
        {
            var subject = new ClaimsIdentity(new[] 
                {
                    new Claim("id", user.Id.ToString())
                });
            return subject;
        }
        private string GenerateJWToken(ClaimsIdentity subject)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_settings.BearerKey);
            var tokenDescriptor = new SecurityTokenDescriptor 
            {
                Subject = subject,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ToDoApp.Entities;
using ToDoApp.Repositories;

namespace ToDoApp.Services
{
    public class AuthenticationService
    {
        private readonly IUserRepository _repository;
        private readonly Settings _settings;

        public AuthenticationService(IUserRepository repository, Settings settings)
        {
            _repository = repository;
            _settings = settings;
        }

        public (bool success, string content) SignUp(string email, string password)
        {
            if (_repository.GetUser(email) != null) { return (false, "Email already in use"); }

            User user = new User(email, password);
            _repository.CreateUser(user);

            return (true, "");
        }
        public (bool success, string token) SignIn(string email, string password)
        {
            User user = _repository.GetUser(email);

            if (user == null) { return (false, "Invalid email"); }
            if (user._passwordHash != User.GetHashedPassword(password, user._salt)) { return (false, "Wrong password"); }

            return (true, GenerateJWToken(GenerateClaimsIdentity(user)));
        }
        private ClaimsIdentity GenerateClaimsIdentity(User user)
        {
            var subject = new ClaimsIdentity
            (
                new[] 
                {
                    new Claim("id", user._userId.ToString())
                }
            );
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
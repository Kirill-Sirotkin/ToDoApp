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



            return (true, "");
        }
    }
}
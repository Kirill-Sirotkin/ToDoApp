namespace ToDoApp.Services
{
    public interface IAuthenticationService
    {
        public (bool success, string content) SignUp(string email, string password);
        public (bool success, string token) SignIn(string email, string password);
        public (bool success, string content) ChangePassword(Guid userId, string newPassword);
    }
}
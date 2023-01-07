using ToDoApp.Entities;

namespace ToDoApp.Repositories
{
    public interface IUserRepository
    {
        public IEnumerable<User> GetUsers();
        public User GetUser(Guid id);
        public User GetUser(string email);
        public void CreateUser(User user);
        public void UpdateUserPassword(Guid id, string password);
        public void DeleteUser(Guid id);
    }
}
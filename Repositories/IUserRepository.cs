using ToDoApp.Entities;

namespace ToDoApp.Repositories
{
    public interface IUserRepository
    {
        public IEnumerable<User> GetUsers();
        public ToDo GetUser(Guid id);
        public void CreateUser(User user);
        public void UpdateUser(Guid id, User user);
        public void DeleteUser(Guid id);
    }
}
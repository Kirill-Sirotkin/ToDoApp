using ToDoApp.Entities;

namespace ToDoApp.Repositories
{
    public class TemporaryUserRepository : IUserRepository
    {
        public List<User> _userList {get; private set;} = new()
        {
            new User("john@gmail", "password"),
            new User("bob@gmail", "wordpass"),
            new User("mary@gmail", "wordpass")
        };

        public void CreateUser(User user)
        {
            _userList.Add(user);
        }

        public void DeleteUser(Guid id)
        {
            int index = _userList.FindIndex(_user => _user._userId == id);
            _userList.RemoveAt(index);
        }

        public User GetUser(Guid id)
        {
            return _userList.Where(user => user._userId == id).SingleOrDefault();
        }

        public User GetUser(string email)
        {
            return _userList.Where(user => user._email == email).SingleOrDefault();
        }

        public IEnumerable<User> GetUsers()
        {
            return _userList;
        }

        public void UpdateUserPassword(Guid id, string password)
        {
            int index = _userList.FindIndex(user => user._userId == id);
            _userList[index].UpdatePassword(password);
        }
    }
}
namespace ToDoApp.Entities
{
    public class User
    {
        public Guid _userId {get; private set;}
        public string _email {get; private set;}
        public string _passwordHash {get; private set;}
        public DateTimeOffset _createdTimestamp {get; private set;}
        public DateTimeOffset _updatedTimestamp {get; private set;}

        public User(string email, string passwordHash)
        {
            _email = email;
            _passwordHash = passwordHash;

            _userId = Guid.NewGuid();
            _createdTimestamp = DateTimeOffset.UtcNow;
            _updatedTimestamp = _createdTimestamp;
        }
    }
}
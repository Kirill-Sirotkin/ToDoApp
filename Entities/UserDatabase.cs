namespace ToDoApp.Entities
{
    public class UserDatabase
    {
        public Guid Id {get; set;}
        public string _email {get; set;}
        public string _passwordHash {get; set;}
        public byte[] _salt {get; set;}
        public DateTimeOffset _createdTimestamp {get; set;}
        public DateTimeOffset _updatedTimestamp {get; set;}
    }
}
namespace ToDoApp.Entities
{
    public class ToDoDatabaseModel
    {
        public Guid Id {get; private set;}
        public string _name {get; private set;}
        public string? _description {get; private set;}
        public DateTimeOffset _createdTimestamp {get; private set;}
        public DateTimeOffset _updatedTimestamp {get; private set;}
        public Status _status {get; private set;}

        public Guid UserId {get; set;}
        public UserDatabaseModel User {get; set;}
    }
}
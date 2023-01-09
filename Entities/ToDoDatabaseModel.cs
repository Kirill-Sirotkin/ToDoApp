namespace ToDoApp.Entities
{
    public class ToDoDatabaseModel
    {
        public Guid Id {get; set;}
        public string _name {get; set;}
        public string? _description {get; set;}
        public DateTimeOffset _createdTimestamp {get; set;}
        public DateTimeOffset _updatedTimestamp {get; set;}
        public Status _status {get; set;}

        public Guid UserId {get; set;}
        public UserDatabaseModel User {get; set;}
    }
}
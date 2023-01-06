namespace ToDoApp.Entities
{
    public class ToDo
    {
        public Guid _id {get; private set;}
        public string _name {get; private set;}
        public string? _description {get; private set;}
        public Guid _userId {get; private set;}
        public DateTimeOffset _createdTimestamp {get; private set;}
        public DateTimeOffset _updatedTimestamp {get; private set;}
        public Status _status {get; private set;}

        public ToDo(string name, Status status, string? description = null)
        {
            _name = name;
            _status = status;
            _description = description;

            _id = Guid.NewGuid();
            _userId = Guid.NewGuid();
            _createdTimestamp = DateTimeOffset.UtcNow;
            _updatedTimestamp = DateTimeOffset.UtcNow;
        }
    }
}
namespace ToDoApp.Entities
{
    public class ToDo
    {
        public Guid _toDoId {get; private set;}
        public string _name {get; private set;}
        public string? _description {get; private set;}
        public Guid _userId {get; private set;}
        public DateTimeOffset _createdTimestamp {get; private set;}
        public DateTimeOffset _updatedTimestamp {get; private set;}
        public Status _status {get; private set;}

        public ToDo(Guid userId, string name, Status status, string? description = null)
        {
            _userId = userId;
            _name = name;
            _status = status;
            _description = description;

            _toDoId = Guid.NewGuid();
            _createdTimestamp = DateTimeOffset.UtcNow;
            _updatedTimestamp = _createdTimestamp;
        }

        public static ToDoDatabaseModel ConvertToDatabaseModel(ToDo toDo)
        {
            return 
            new ToDoDatabaseModel
            {
                Id = toDo._toDoId,
                _name = toDo._name,
                _description = toDo._description,
                _createdTimestamp = toDo._createdTimestamp,
                _updatedTimestamp = toDo._updatedTimestamp,
                _status = toDo._status
            };
        }
        public void UpdateToDo(string name, string description, Status status)
        {
            _name = name;
            _description = description;
            _status = status;

            _updatedTimestamp = DateTimeOffset.UtcNow;
        }
    }
}
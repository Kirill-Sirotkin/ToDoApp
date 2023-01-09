using ToDoApp.Entities;
using ToDoApp.Repositories;

namespace ToDoApp.Services
{
    public class ToDoService : IToDoService
    {
        private readonly DataBaseContext _database;

        public ToDoService(DataBaseContext database)
        {
            _database = database;
        }

        public List<ToDoDatabaseModel> GetToDos(Guid userId)
        {
            List<ToDoDatabaseModel> toDos = _database.ToDos.Where
            (
                t => 
                t.UserId == userId
            ).ToList();

            return toDos;
        }

        public List<ToDoDatabaseModel> GetToDos(Guid userId, Status toDoStatus)
        {
            List<ToDoDatabaseModel> toDos = _database.ToDos.Where
            (
                t => 
                t.UserId == userId &&
                t._status == toDoStatus
            ).ToList();

            return toDos;
        }

        public ToDoDatabaseModel CreateToDo(Guid userId, ToDo toDo)
        {
            UserDatabaseModel userDb = _database.Users.SingleOrDefault(u => u.Id == userId);

            if (userDb == null) { return null; }

            ToDoDatabaseModel toDoDb = ToDo.ConvertToDatabaseModel(toDo);
            toDoDb.UserId = userId;
            toDoDb.User = userDb;

            _database.Add(toDoDb);
            _database.SaveChanges();

            toDoDb.User = null;
            return toDoDb;
        }

        public (bool, string) UpdateToDo(Guid userId, Guid toDoId, ToDo toDo)
        {
            ToDoDatabaseModel toDoDb = _database.ToDos.SingleOrDefault
            (
                t => 
                t.UserId == userId &&
                t.Id == toDoId
            );

            if (toDoDb == null) { return (false, "Specified ToDo was not found"); }

            toDoDb._name = toDo._name;
            toDoDb._description = toDo._description;
            toDoDb._status = toDo._status;

            _database.SaveChanges();

            return (true, "ToDo updated successfully");
        }

        public (bool, string) DeleteToDo(Guid userId, Guid toDoId)
        {
            ToDoDatabaseModel toDoDb = _database.ToDos.SingleOrDefault
            (
                t => 
                t.UserId == userId &&
                t.Id == toDoId
            );

            if (toDoDb == null) { return (false, "Specified ToDo was not found"); }

            _database.Remove(toDoDb);
            _database.SaveChanges();
            
            return (true, "ToDo deleted successfully");
        }
    }
}
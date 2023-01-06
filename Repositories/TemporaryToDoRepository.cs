using ToDoApp.Entities;

namespace ToDoApp.Repositories
{
    public class TemporaryToDoRepository
    {
        public List<ToDo> _toDoList {get; private set;} = new()
        {
            new ToDo(Guid.NewGuid(), "Study", Status.OnGoing),
            new ToDo(Guid.NewGuid(), "Walk", Status.Completed),
            new ToDo(Guid.NewGuid(), "Shower", Status.NotStarted),
        };

        public IEnumerable<ToDo> GetToDos()
        {
            return _toDoList;
        }
        public ToDo GetToDo(Guid id)
        {
            return _toDoList.Where(toDo => toDo._toDoId == id).SingleOrDefault();
        }
    }
}
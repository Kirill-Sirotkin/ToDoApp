using ToDoApp.Entities;

namespace ToDoApp.Repositories
{
    public interface IToDoRepository
    {
        public IEnumerable<ToDo> GetToDos();
    }
}
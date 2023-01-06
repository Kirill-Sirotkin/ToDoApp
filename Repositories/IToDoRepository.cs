using ToDoApp.Entities;

namespace ToDoApp.Repositories
{
    public interface IToDoRepository
    {
        public IEnumerable<ToDo> GetToDos();
        public ToDo GetToDo(Guid id);
        public void CreateToDo(ToDo toDo);
        public void UpdateToDo(ToDo toDo);
        public void DeleteToDo(Guid id);
    }
}
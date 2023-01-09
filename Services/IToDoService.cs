using ToDoApp.DTOs;
using ToDoApp.Entities;

namespace ToDoApp.Services
{
    public interface IToDoService
    {
        public List<ToDoDatabaseModel> GetToDos(Guid userId);
        public List<ToDoDatabaseModel> GetToDos(Guid userId, Status toDoStatus);
        public ToDoDatabaseModel CreateToDo(ToDo toDo);
        public (bool, string) UpdateToDo(Guid userId, Guid toDoId, ToDo toDo);
        public (bool, string) DeleteToDo(Guid userId, Guid toDoId);
    }
}
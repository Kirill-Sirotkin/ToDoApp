using Microsoft.AspNetCore.Mvc;
using ToDoApp.DTOs;
using ToDoApp.Entities;
using ToDoApp.Repositories;

namespace ToDoApp.Controllers
{
    [ApiController]
    [Route("api/v1/todos")]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoRepository _repository;

        public ToDoController(IToDoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<ToDo> GetToDos()
        {
            return _repository.GetToDos();
        }

        [HttpPost]
        public ToDo CreateToDo(ToDoDTO toDoDTO)
        {
            ToDo toDo = new ToDo
            (
                Guid.NewGuid(),
                toDoDTO._name,
                toDoDTO._status,
                toDoDTO._description
            );

            _repository.CreateToDo(toDo);
            return toDo;
        }

        [HttpPut("{id}")]
        public void UpdateToDo(Guid id, ToDoDTO toDoDTO)
        {

        }
    }
}
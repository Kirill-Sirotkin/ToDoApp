using Microsoft.AspNetCore.Mvc;
using ToDoApp.Entities;
using ToDoApp.Repositories;

namespace ToDoApp.Controllers
{
    [ApiController]
    [Route("api/v1/todos")]
    public class ToDoController : ControllerBase
    {
        private readonly TemporaryToDoRepository _repository;

        public ToDoController()
        {
            _repository = new TemporaryToDoRepository();
        }

        [HttpGet]
        public IEnumerable<ToDo> GetToDos()
        {
            var toDos = _repository.GetToDos();
            return toDos;
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using ToDoApp.DTOs;
using ToDoApp.Entities;
using ToDoApp.Repositories;

namespace ToDoApp.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet]
        public IEnumerable<User> GetToDos()
        {
            return _repository.GetUsers();
        }

        [HttpPost]
        public User CreateToDo(UserDTO userDTO)
        {
            User user = new User
            (
                userDTO._email, 
                userDTO._password
            );

            _repository.CreateUser(user);
            return user;
        }

        [HttpPut("{id}")]
        public void UpdateUserPassword(Guid id, string password)
        {
            User user = _repository.GetUser(id);

            if (user == null){ return; }

            _repository.UpdateUserPassword(id, password);
        }
    }
}
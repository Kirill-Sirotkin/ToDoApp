using System.ComponentModel.DataAnnotations;
using ToDoApp.Entities;

namespace ToDoApp.DTOs
{
    public class UserDTO
    {
        [Required]
        public string? _email {get; set;}
        [Required]
        public string? _password {get; set;}
    }
}
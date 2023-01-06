using System.ComponentModel.DataAnnotations;
using ToDoApp.Entities;

namespace ToDoApp.DTOs
{
    public class ToDoDTO
    {
        [Required]
        public string? _name {get; private set;}
        public string? _description {get; private set;}
        public Status _status {get; private set;}
    }
}
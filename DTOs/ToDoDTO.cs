using System.ComponentModel.DataAnnotations;
using ToDoApp.Entities;

namespace ToDoApp.DTOs
{
    public class ToDoDTO
    {
        [Required]
        public string? _name {get; set;}
        public string? _description {get; set;}
        [Required]
        public Status _status {get; set;}
    }
}
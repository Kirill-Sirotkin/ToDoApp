using Microsoft.EntityFrameworkCore;
using ToDoApp.Entities;

namespace ToDoApp.Repositories
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

        public DbSet<UserDatabaseModel> Users {get; set;}
        public DbSet<ToDoDatabaseModel> ToDos {get; set;}
    }
}
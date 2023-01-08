using Microsoft.EntityFrameworkCore;
using ToDoApp.Entities;

namespace ToDoApp.Repositories
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

        public DbSet<UserDatabase> _users {get; set;}
    }
}
using Microsoft.EntityFrameworkCore;
using MinimalTodos.Domain;

namespace MinimalTodos.Data
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {

        }
        public DbSet<TodoList> ToDoLists => Set<TodoList>();
        public DbSet<Todo> Todos => Set<Todo>();
    }
}

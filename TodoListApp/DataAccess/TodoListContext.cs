namespace TodoListApp.DataAccess


{
    using Microsoft.EntityFrameworkCore;
    using TodoListApp.Models;

    public class TodoListContext : DbContext
    {
        public TodoListContext(DbContextOptions<TodoListContext> options) : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }

}

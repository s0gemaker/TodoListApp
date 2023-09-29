using TodoListApp.Models;
using System.Collections.Generic;
using System.Linq;
using TodoListApp.DataAccess;

namespace TodoListApp.BusinessLogic
{
    public class TodoManager
    {
        private readonly TodoListContext _context;

        public TodoManager(TodoListContext context)
        {
            _context = context;
        }

        public List<TodoItem> GetAllItems()
        {
            return _context.TodoItems.ToList();
        }

        public TodoItem? GetItemById(int id)
        {
            return _context.TodoItems.Find(id);
        }

        public void AddItem(TodoItem item)
        {
            _context.TodoItems.Add(item);
            _context.SaveChanges();
        }

        public void UpdateItem(TodoItem item)
        {
            _context.Update(item);
            _context.SaveChanges();
        }

        public void DeleteItem(int id)
        {
            var item = _context.TodoItems.Find(id);
            if (item != null)
            {
                _context.TodoItems.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using TodoListApp.Models;
using TodoListApp.DataAccess;
using System.Linq;

namespace TodoListWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly TodoListContext _context;

        public TodoController(TodoListContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.TodoItems.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<TodoItem> Get(int id)
        {
            var item = _context.TodoItems.Find(id);
            if (item == null) return NotFound();
            return item;
        }

        [HttpPost]
        public ActionResult<TodoItem> Create(TodoItem newItem)
        {
            _context.TodoItems.Add(newItem);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = newItem.Id }, newItem);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, TodoItem updatedItem)
        {
            var item = _context.TodoItems.Find(id);
            if (item == null) return NotFound();

            item.Description = updatedItem.Description;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _context.TodoItems.Find(id);
            if (item == null) return NotFound();

            _context.TodoItems.Remove(item);
            _context.SaveChanges();

            return NoContent();
        }
    }
}

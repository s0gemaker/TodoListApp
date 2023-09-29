using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TodoListApp.Models;
using Microsoft.Extensions.Logging;
using TodoListApp.BusinessLogic;

namespace TodoListApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TodoManager _todoManager; // TodoManager field

        // Updated constructor to receive TodoManager as a parameter
        public HomeController(ILogger<HomeController> logger, TodoManager todoManager)
        {
            _logger = logger;
            _todoManager = todoManager; // Set the received TodoManager instance to the field.
        }

        public IActionResult Index()
        {
            var items = _todoManager.GetAllItems();
            return View(items);
        }

        [HttpPost]
        public IActionResult Create(TodoItem newItem)
        {
            _todoManager.AddItem(newItem);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var item = _todoManager.GetItemById(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        [HttpPost]
        public IActionResult Update(TodoItem updatedItem)
        {
            _todoManager.UpdateItem(updatedItem);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _todoManager.DeleteItem(id);
            return RedirectToAction("Index");
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

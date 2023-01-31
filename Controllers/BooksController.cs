using BookSale.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookSale.Controllers
{
    //Route = controller/action
    public class BooksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details()
        {
            var book = new Books()
            {
                Id = Guid.NewGuid(),
                Title = "Learn with Athena MVC",
                Genre = "Programming & Software Development",
                Price = 55,
                PublishDate = new System.DateTime(2023,01,31),
                Authors= new List<string> {"Burak Tamince","Ahmet Kara" }
            };
            return View(book);
        }
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Books newBook)
        {
            if(ModelState.IsValid)
            {
                //logic to use database
                return RedirectToAction("Index");   
            }
            return View(newBook);
        }
    }
}

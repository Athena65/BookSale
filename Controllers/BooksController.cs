using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookSale.Data;
using BookSale.Models;
using BookSale.Services;

namespace BookSale.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _bookService.GetAllBooks());
        }
        public async Task<IActionResult> Details(Guid? id)
        {
            try
            {
                var books = await _bookService.GetBookById(id);
                return View(books);
            }
            catch (Exception ex)
            {
                var response = new ServiceResponse();
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Genre,Price,PublishDate")] Book books)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _bookService.CreateBook(books);
                    return RedirectToAction(nameof(Index));
                }
                return View(books);
            }
            catch (Exception ex)
            {
                var response = new ServiceResponse();
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }

        }
        public async Task<IActionResult> Edit(Guid? id,Book book)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _bookService.UpdateBook(id,book);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BooksExists(book.Id))
                    {
                        var response = new ServiceResponse();
                        response.Success=false;
                        response.Message = "Book Doesnt Exist";
                        return BadRequest(response);
                    }
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(book);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Book books)
        {
            try
            {
                await _bookService.UpdateBook(id, books);
                if (ModelState.IsValid)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View(books);
            }
            catch (Exception ex)
            {
                var response = new ServiceResponse();
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }

        // GET: Books1/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            try
            {
                var books = await _bookService.GetBookById(id);
                return View(books);
            }
            catch (Exception ex)
            {
                var response = new ServiceResponse();
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                await _bookService.DeleteBook(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                var response = new ServiceResponse();
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }

        }

        private bool BooksExists(Guid id)
        {
            return _bookService.BooksExists(id);
        }


    }

}

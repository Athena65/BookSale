using BookSale.Data;
using BookSale.Models;
using Microsoft.EntityFrameworkCore;

namespace BookSale.Services
{
    public class BookService : IBookService
    {
        private readonly BookSaleContext _context;

        public BookService(BookSaleContext context)
        {
            _context = context;
        }

        public bool BooksExists(Guid id)
        {
            return _context.Books.Any(e => e.Id == id);
        }

        public async Task<Books> CreateBook(Books newBook)
        {
            newBook.Id= Guid.NewGuid(); 
            await _context.Books.AddAsync(newBook); 
            await _context.SaveChangesAsync();
            return newBook;
        }

        public async Task<Books> DeleteBook(Guid id)
        {
           var deleted= await _context.Books.FirstOrDefaultAsync(x=> x.Id==id); 

            _context.Books.Remove(deleted);
            await _context.SaveChangesAsync();
            return deleted;
        }

        public async Task<List<Books>> GetAllBooks()
        {
            return await _context.Books.ToListAsync();
            
        }

        public async Task<Books> GetBookById(Guid? id)
        {
            return await _context.Books.Where(x => x.Id == id).FirstOrDefaultAsync();
        }


        public async Task<Books> UpdateBook(Guid id, Books book)
        {
            var newBook=await _context.Books.Where(x=>x.Id==id).FirstOrDefaultAsync();  

            newBook.Title=book.Title;
            newBook.PublishDate=book.PublishDate;
            newBook.Genre=book.Genre;
            newBook.Price=book.Price;

            await _context.SaveChangesAsync();
            return newBook;
        }
    }
}

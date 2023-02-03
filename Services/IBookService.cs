using BookSale.Models;

namespace BookSale.Services
{
    public interface IBookService
    {
        Task<Book> CreateBook(Book newBook);
        Task<List<Book>> GetAllBooks();
        Task<Book> GetBookById(Guid? id);
        Task<Book> UpdateBook(Guid? id, Book book);
        Task<Book> DeleteBook(Guid id);
        bool BooksExists(Guid id);
    }
}

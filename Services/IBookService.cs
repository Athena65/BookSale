using BookSale.Models;

namespace BookSale.Services
{
    public interface IBookService
    {
        Task<Books> CreateBook(Books newBook);
        Task<List<Books>> GetAllBooks();
        Task<Books> GetBookById(Guid? id);
        Task<Books> UpdateBook(Guid id, Books book);
        Task<Books> DeleteBook(Guid id);
        bool BooksExists(Guid id);
    }
}

using Microsoft.EntityFrameworkCore;
using BookSale.Models;

namespace BookSale.Data
{
    public class BookSaleContext : DbContext
    {
        public BookSaleContext (DbContextOptions<BookSaleContext> options): base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id=Guid.NewGuid(),
                Title="NewBook",
                Genre="Fiction",
                Price=20,
                PublishDate=new DateTime(2023,1,24)
            },new Book
            {
                Id = Guid.NewGuid(),
                Title = "SecondBook",
                Genre = "History",
                Price =30,
                PublishDate = new DateTime(2022, 1, 24)
            });
        }

        public DbSet<Book> Books { get; set; }
    }
}

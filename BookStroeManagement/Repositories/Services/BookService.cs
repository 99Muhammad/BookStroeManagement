using BookStroeManagement.Data;
using BookStroeManagement.Models;
using BookStroeManagement.Repositories.Interfacees;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BookStroeManagement.Repositories.Services
{
    public class BookService : IBook
    {
        private readonly BookDbContext _context;

        public BookService(BookDbContext context)
        {
            _context = context;
        }
        public async Task<Book> CreateBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return book;
        }
        public async Task<List<Book>> GetAllBooks()
        {
            var allSongs = await _context.Books.ToListAsync();
            return allSongs;
        }

        public async Task<Book> GetBookByID(int BookID)
        {
            var Book = await _context.Books.FindAsync(BookID);
            return Book;
        }

        public async Task<Book> UpdateBookInfo(int BookID, Book book)
        {
            var BookToUpdate = await _context.Books.FindAsync(BookID);

            // Update properties

            BookToUpdate.Title = book.Title;
            BookToUpdate.Author = book.Author;
            BookToUpdate.Price = book.Price;
            BookToUpdate.Genre = book.Genre;
            //BookToUpdate = book;
            await _context.SaveChangesAsync();
            return BookToUpdate;
        }

        public async Task<Book> GetBookByName(string BookName)
        {
            var Book =  await _context.Books.FirstOrDefaultAsync(b => b.Title == BookName); ;
            return Book;
        }

        public async Task <Book> DeleteBook(string BookName)
        {
           
            var BookToDelete = await GetBookByName(BookName);
            _context.Entry(BookToDelete).State = EntityState.Deleted;
            //_context.Books.Remove(BookToDelete);
            await _context.SaveChangesAsync();
            return BookToDelete;
        }

        public Task<Book> ViewBookDetails(string BookName)
        {
          return GetBookByName(BookName);
        }
    }
}

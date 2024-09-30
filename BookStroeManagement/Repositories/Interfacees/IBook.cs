using BookStroeManagement.Models;

namespace BookStroeManagement.Repositories.Interfacees
{
    public interface IBook
    {
        Task<Book> CreateBook(Book book);

        Task<List<Book>> GetAllBooks();

        Task<Book> UpdateBookInfo(int BookID,Book book);

        Task<Book> GetBookByID(int BookID);

        Task<Book> DeleteBook(string BookName);

        Task<Book> ViewBookDetails(string BookName);
    }
}

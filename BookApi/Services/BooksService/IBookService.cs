using BookApi.Models;

namespace BookApi.Services.BooksService
{
    public interface IBookService
    {
        IEnumerable<Book> GetBooks();
        Book GetBook(int id);
        Book AddBook(BookDto book);
        Book UpdateBook(int id, BookDto book);
        Book DeleteBook(int id);
    }
}

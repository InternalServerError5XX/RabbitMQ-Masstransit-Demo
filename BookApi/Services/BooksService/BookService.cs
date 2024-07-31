using Contracts.Models;

namespace BookApi.Services.BooksService
{
    public class BookService : IBookService
    {
        private static List<Book> books = new List<Book>
        {
            new Book{ Id = 1, Title = "Book1", Author = "Author1" },
            new Book{ Id = 2, Title = "Book2", Author = "Author2" },
            new Book{ Id = 3, Title = "Book3", Author = "Author3"}
        };

        public IEnumerable<Book> GetBooks()
        {
            return books;
        }

        public Book GetBook(int id)
        {
            var book = books.FirstOrDefault(x => x.Id == id);
            if (book == null)
                throw new NullReferenceException("Book not found");

            return book;
        }

        public Book AddBook(BookDto bookDto)
        {
            var book = new Book
            {
                Id = books.Max(x => x.Id) + 1,
                Author = bookDto.Author,
                Title = bookDto.Title,
            };

            books.Add(book);
            return book;
        }

        public Book UpdateBook(int id, BookDto bookDto)
        {
            var book = GetBook(id);
            book.Author = bookDto.Author;
            book.Title = bookDto.Title;

            return book;
        }

        public Book DeleteBook(int id)
        {
            var book = GetBook(id);
            books.Remove(book);

            return book;
        }
    }
}

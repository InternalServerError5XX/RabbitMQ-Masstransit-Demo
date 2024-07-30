using BookApi.Models;

namespace BookApi.Messages
{
    public class BooksMessage
    {
        public IEnumerable<Book> Books { get; set; } = [];
    }
}

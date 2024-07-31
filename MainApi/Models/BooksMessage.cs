using MainApi.Models;

namespace MainApi.Messages
{
    public class BooksMessage
    {
        public IEnumerable<Book> Books { get; set; } = [];
    }
}

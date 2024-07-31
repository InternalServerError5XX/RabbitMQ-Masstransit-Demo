using Contracts.Models;

namespace Contracts.Messages
{
    public class BooksMessage
    {
        public IEnumerable<Book> Books { get; set; } = [];
    }
}

using BookApi.Models;

namespace BookApi.Messages
{
    public class BookAddedMessage
    {
        public Book Book { get; set; } = null!;
    }
}

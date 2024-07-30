using BookApi.Models;

namespace BookApi.Messages
{
    public class BookMessage
    {
        public Book Book { get; set; } = null!;
    }
}

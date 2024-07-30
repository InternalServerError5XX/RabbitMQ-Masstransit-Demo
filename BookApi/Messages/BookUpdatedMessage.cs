using BookApi.Models;

namespace BookApi.Messages
{
    public class BookUpdatedMessage
    {
        public Book Book { get; set; } = null!;
    }
}

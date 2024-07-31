using Contracts.Models;

namespace Contracts.Messages
{
    public class BookAddedMessage
    {
        public Book Book { get; set; } = null!;
    }
}

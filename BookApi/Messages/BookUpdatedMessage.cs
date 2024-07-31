using Contracts.Models;

namespace Contracts.Messages
{
    public class BookUpdatedMessage
    {
        public Book Book { get; set; } = null!;
    }
}

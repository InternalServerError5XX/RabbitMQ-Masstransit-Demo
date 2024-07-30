using BookApi.Messages;
using MassTransit;

namespace BookApi.Consumers
{
    public class BookUpdatedConsumer : IConsumer<BookUpdatedMessage>
    {
        public async Task Consume(ConsumeContext<BookUpdatedMessage> context)
        {
            var book = context.Message;

            Console.WriteLine($"Book updated Consumer performed");
            await Task.CompletedTask;
        }
    }
}

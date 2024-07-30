using BookApi.Messages;
using MassTransit;

namespace BookApi.Consumers
{
    public class BookAddedConsumer : IConsumer<BookAddedMessage>
    {
        public async Task Consume(ConsumeContext<BookAddedMessage> context)
        {
            var book = context.Message;

            Console.WriteLine($"Book added Consumer performed");
            await Task.CompletedTask;
        }
    }
}

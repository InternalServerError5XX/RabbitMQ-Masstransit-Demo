using BookApi.Messages;
using MassTransit;

namespace BookApi.Consumers
{
    public class BookDeletedConsumer : IConsumer<BookDeletedMessage>
    {
        public async Task Consume(ConsumeContext<BookDeletedMessage> context)
        {
            var book = context.Message;

            Console.WriteLine($"Book deleted Consumer performed");
            await Task.CompletedTask;
        }
    }
}

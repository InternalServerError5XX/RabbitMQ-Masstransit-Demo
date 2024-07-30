using BookApi.Messages;
using BookApi.Models;
using MassTransit;

namespace BookApi.Consumers
{
    public class BookConsumer : IConsumer<BookMessage>
    {
        public async Task Consume(ConsumeContext<BookMessage> context)
        {
            var message = context.Message;

            Console.WriteLine($"Book Consumer performed");
            await Task.CompletedTask;
        }
    }
}

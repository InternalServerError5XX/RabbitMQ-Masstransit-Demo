using BookApi.Messages;
using BookApi.Models;
using MassTransit;

namespace BookApi.Consumers
{
    public class BooksConsumer : IConsumer<BooksMessage>
    {
        public async Task Consume(ConsumeContext<BooksMessage> context)
        {
            var books = context.Message;

            Console.WriteLine($"Books Consumer performed");
            await Task.CompletedTask;
        }
    }
}

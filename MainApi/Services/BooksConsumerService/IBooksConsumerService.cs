using BookApi.Messages;
using MainApi.Services.BaseConsumer;

namespace MainApi.Services.BooksConsumerService
{
    public interface IBooksConsumerService : IConsumerService<BooksMessage>;
}

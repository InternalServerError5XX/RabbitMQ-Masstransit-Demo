using Contracts.Models;
using MainApi.Services.BaseConsumer;

namespace MainApi.Services.BookConsumerService
{
    public interface IBookConsumerService : IConsumerService<Book>;
}

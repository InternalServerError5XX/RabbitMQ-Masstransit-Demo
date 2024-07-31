using Contracts.Models;
using MainApi.Services.BaseConsumer;
using MainApi.Services.StoreService;

namespace MainApi.Services.BookConsumerService
{
    public class BookConsumerService : ConsumerService<Book>, IBookConsumerService
    {
        public BookConsumerService(IStoreService storeService, ILogger<Book> logger) : base(storeService, logger)
        {
        }
    }
}

using BookApi.Messages;
using MainApi.Services.BaseConsumer;
using MainApi.Services.StoreService;

namespace MainApi.Services.BooksConsumerService
{
    public class BooksConsumerService : ConsumerService<BooksMessage>, IBooksConsumerService
    {
        public BooksConsumerService(IStoreService storeService, ILogger<BooksMessage> logger) : base(storeService, logger)
        {
        }
    }
}

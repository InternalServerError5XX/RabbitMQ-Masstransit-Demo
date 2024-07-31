using MainApi.Services.StoreService;
using MassTransit;
using Newtonsoft.Json;

namespace MainApi.Services.BaseConsumer
{
    public class ConsumerService<T>(IStoreService storeService, ILogger<T> logger) : IConsumerService<T> where T : class
    {

        public async Task Consume(ConsumeContext<T> context)
        {
            var message = context.Message;
            storeService.StoreMessage(message);

            var serailized = JsonConvert.SerializeObject(message, Formatting.Indented);
            logger.LogInformation($"{typeof(T)} consumer performed: {serailized}");
            await Task.CompletedTask;
        }

        public T GetMessage()
        {
            return storeService.GetMessage<T>();
        }
    }
}

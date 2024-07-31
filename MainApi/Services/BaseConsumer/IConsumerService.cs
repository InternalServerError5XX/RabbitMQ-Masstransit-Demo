using MassTransit;

namespace MainApi.Services.BaseConsumer
{
    public interface IConsumerService<T> : IConsumer<T> where T : class
    {
        T GetMessage();
    }
}

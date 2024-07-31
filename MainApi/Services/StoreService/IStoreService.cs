namespace MainApi.Services.StoreService
{
    public interface IStoreService
    {
        T GetMessage<T>();
        void StoreMessage<T>(T message);
    }
}

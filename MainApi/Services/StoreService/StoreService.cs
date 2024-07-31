namespace MainApi.Services.StoreService
{
    public class StoreService : IStoreService
    {
        private object? _message;
            
        public T GetMessage<T>()
        {
            if (_message == null)
                return default;

            return (T)_message;
        }

        public void StoreMessage<T>(T message)
        {
            _message = message;
        }
    }
}

namespace Order.Application
{
    public interface IDistributedEventBus
    {
        Task PublishAsync<T>(T message);
    }
}

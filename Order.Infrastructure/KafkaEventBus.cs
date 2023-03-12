using Order.Application;

namespace Order.Infrastructure
{
    public class KafkaEventBus : IDistributedEventBus
    {
        public Task PublishAsync<T>(T message)
        {
            throw new NotImplementedException();
        }
    }
}

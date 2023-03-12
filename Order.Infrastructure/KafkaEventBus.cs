using Order.Application;

namespace Order.Infrastructure
{
    public class KafkaEventBus : IDistributedEventBus
    {
        public async Task PublishAsync<T>(T message)
        {
            await Task.Delay(1000);
        }
    }
}

using Order.Domain.Order;

namespace Order.Infrastructure
{
    public class OrderRepository : IOrderRepository
    {
        public Task SaveOrderAsync(Domain.Order.Order order)
        {
            throw new NotImplementedException();
        }
    }
}

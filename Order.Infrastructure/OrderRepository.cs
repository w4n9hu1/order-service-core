using Order.Domain.Order;

namespace Order.Infrastructure
{
    public class OrderRepository : IOrderRepository
    {
        public Task<Domain.Order.Order> GetAsync(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(Domain.Order.Order order)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Domain.Order.Order order)
        {
            throw new NotImplementedException();
        }
    }
}

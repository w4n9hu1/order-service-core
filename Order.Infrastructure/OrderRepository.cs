using Order.Domain.Order;
using Order.Domain.Shared;

namespace Order.Infrastructure
{
    public class OrderRepository : IOrderRepository
    {
        public Task<Domain.Order.Order> GetAsync(int orderId)
        {
            throw new EntityNotFoundException(nameof(orderId));
        }

        public Task InsertAsync(Domain.Order.Order order)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Domain.Order.Order order)
        {
            throw new NotImplementedException();
        }
    }
}

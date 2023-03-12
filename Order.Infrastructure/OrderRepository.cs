using Order.Domain.Order;
using Order.Domain.Shared;

namespace Order.Infrastructure
{
    public class OrderRepository : IOrderRepository
    {
        public async Task<Domain.Order.Order> GetAsync(int orderId)
        {
            throw new EntityNotFoundException(nameof(orderId));
        }

        public async Task<Domain.Order.Order> InsertAsync(Domain.Order.Order order)
        {
            throw new NotImplementedException();
        }

        public async  Task UpdateAsync(Domain.Order.Order order)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AnyAsync(string orderCode)
        {
            throw new NotImplementedException();
        }
    }
}

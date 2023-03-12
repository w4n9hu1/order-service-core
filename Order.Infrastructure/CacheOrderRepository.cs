using Microsoft.Extensions.Caching.Memory;
using Order.Domain.Order;

namespace Order.Infrastructure
{
    public class CacheOrderRepository : IOrderRepository
    {
        private readonly string CACHEKEY = "order";

        private readonly IMemoryCache _memoryCache;

        public CacheOrderRepository(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public async Task<Domain.Order.Order?> GetAsync(int orderId)
        {
            if (!_memoryCache.TryGetValue(CACHEKEY, out List<Domain.Order.Order>? cacheOrders))
            {
                return null;
            }
            return cacheOrders?.FirstOrDefault(o => o.OrderId == orderId);
        }

        public async Task<IEnumerable<Domain.Order.Order>?> GetAllAsync()
        {
            return _memoryCache.Get<List<Domain.Order.Order>?>(CACHEKEY);
        }

        public async Task<Domain.Order.Order> InsertAsync(Domain.Order.Order order)
        {
            if (!_memoryCache.TryGetValue(CACHEKEY, out List<Domain.Order.Order>? cacheOrders))
            {
                cacheOrders = new List<Domain.Order.Order>();
            }
            order.OrderId = cacheOrders.LastOrDefault()?.OrderId == null ? 1 : cacheOrders.Last().OrderId + 1;
            cacheOrders.Add(order);

            var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(1));
            _memoryCache.Set(CACHEKEY, cacheOrders, cacheEntryOptions);

            return order;
        }

        public async Task UpdateAsync(Domain.Order.Order order)
        {
            var cacheOrders = _memoryCache.Get<List<Domain.Order.Order>?>(CACHEKEY);
            int index = cacheOrders.FindIndex(o => o.OrderId == order.OrderId);
            cacheOrders[index] = order;
            _memoryCache.Set(CACHEKEY, cacheOrders);
        }

        public async Task<bool> AnyAsync(string orderCode)
        {
            if (!_memoryCache.TryGetValue(CACHEKEY, out List<Domain.Order.Order>? cacheOrders))
            {
                return false;
            }
            return cacheOrders.Any(o => o.OrderCode == orderCode);
        }
    }
}

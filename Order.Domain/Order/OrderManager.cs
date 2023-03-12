namespace Order.Domain.Order
{
    /**
     * Domain Services work with Domain Objects. Their methods can get and return entities, value objects, primitive types... etc.
     * Do not create Domain Service methods just for simple CRUD operations without any domain logic.
     */
    public class OrderManager
    {
        private readonly IOrderRepository _orderRepository;

        public OrderManager(IOrderRepository orderRepository)
        {
            this._orderRepository = orderRepository;
        }

        public async Task<Order> CreateAsync(string orderCode)
        {
            //  core business rule: duplicate orderCode check
            if (await _orderRepository.AnyAsync(orderCode))
            {
                throw new OrderException("This orderCode Exists!");
            }
            return new Order(orderCode);
        }
    }
}

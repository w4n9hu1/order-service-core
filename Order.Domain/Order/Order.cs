namespace Order.Domain.Order
{
    /** Entity: An Entity is an object with its own properties
    (state, data) and methods that implements the business
    logic that is executed on these properties. An entity is
    represented by its unique identifier (Id). Two entity object
    with different Ids are considered as different entities.
     */
    public class Order : IAggregateRoot
    {
        public int OrderId { get; set; }

        public string OrderCode { get; set; }

        public Order(string orderCode, List<OrderItem> orderItems)
        {
            if (string.IsNullOrEmpty(orderCode))
            {
                throw new OrderException("OrderCode should have value!");
            }

            if (orderItems == null || !orderItems.Any())
            {
                throw new OrderException("OrderItems should have orderItems!");
            }

            if (orderItems.Any(i => i.Amount == 0))
            {
                throw new OrderException("Commodity's amount should not be 0!");
            }

            OrderCode = orderCode;
            OrderItems = orderItems;
        }

        public Weight Weight { get; set; }

        public List<OrderItem> OrderItems { get; set; }

        public int Amount
        {
            get
            {
                return OrderItems.Sum(i => i.Amount);
            }
        }

        public int CreatedBy { get; set; }

        public DateTimeOffset CreatedTime { get; set; }

        public void AddOrderItem(OrderItem orderItem)
        {
            if (orderItem.Amount == 0)
            {
                throw new OrderException("Commodity's amount should not be 0!");
            }
            OrderItems.Add(orderItem);
        }
    }
}

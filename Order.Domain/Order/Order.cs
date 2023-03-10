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

        internal Order(string orderCode)
        {
            if (string.IsNullOrEmpty(orderCode))
            {
                throw new OrderException("OrderCode should have value!");
            }

            OrderCode = orderCode;
        }

        public Weight Weight { get; set; }

        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public int TotalAmount
        {
            get
            {
                return OrderItems.Sum(i => i.Amount);
            }
        }

        public int CreatedBy { get; set; }

        public DateTimeOffset CreatedTime { get; set; } = DateTimeOffset.Now;

        public void AddOrderItem(OrderItem orderItem)
        {
            OrderItems.Add(orderItem);
        }
    }
}

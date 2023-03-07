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

        public string OrderCode { get; set; } = string.Empty;

        public Weight Weight { get; set; }

        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public int Amount { get; set; }

        public int CreatedBy { get; set; }

        public DateTimeOffset CreatedTime { get; set; }

        public void AddOrderItem(OrderItem orderItem)
        {
            OrderItems.Add(orderItem);
        }
    }
}

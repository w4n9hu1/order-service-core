namespace Order.Domain.Order
{
    public class Order : IAggregateRoot
    {
        public int OrderId { get; set; }

        public string OrderCode { get; set; } = string.Empty;

        public Weight Weight { get; set; }

        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public int Amount { get; set; }

        public int CreatedBy { get; set; }

        public DateTimeOffset CreatedTime { get; set; }
    }
}

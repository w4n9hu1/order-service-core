using Order.Domain.Order;

namespace Order.Application.Contracts.Dto
{
    /**
     * Output Dto
     */
    public class OrderDto
    {
        public int OrderId { get; set; }

        public string OrderCode { get; set; } = string.Empty;

        public Weight Weight { get; set; }

        public int TotalAmount { get; set; }

        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public int CreatedBy { get; set; }

        public DateTimeOffset CreatedTime { get; set; }
    }
}

using Order.Domain.Order;

namespace Order.Application.Contracts.Dto
{
    public class CreateOrderRequest
    {
        public string OrderCode { get; set; }

        public Weight Weight { get; set; }

        public List<OrderItem> OrderItems { get; set; }

        public int CreatedBy { get; set; }
    }
}

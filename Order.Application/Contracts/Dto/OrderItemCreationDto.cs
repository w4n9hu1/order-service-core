namespace Order.Application.Contracts.Dto
{
    public class OrderItemCreationDto
    {
        public int OrderId { get; set; }
        public int CreatedBy { get; set; }
        public OrderItem OrderItem { get; set; } = new OrderItem();
    }
}

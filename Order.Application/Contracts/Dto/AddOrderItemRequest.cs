namespace Order.Application.Contracts.Dto
{
    public class AddOrderItemRequest
    {
        public int OrderId { get; set; }
        public int CreatedBy { get; set; }
        public OrderItem OrderItem { get; set; }
    }
}

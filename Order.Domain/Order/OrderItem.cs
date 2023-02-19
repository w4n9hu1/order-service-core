namespace Order.Domain.Order
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int CommodityId { get; set; }
        public string CommodityName { get; set; }
        public int Amount { get; set; }
    }
}

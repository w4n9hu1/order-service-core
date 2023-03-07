namespace Order.Domain.Order
{
    /** Entity.
     */
    public class OrderItem
    {
        public OrderItem(int commodityId, string commodityName, int amount)
        {
            if (amount == 0)
            {
                throw new OrderException("Commodity's amount should not be 0!");
            }
            CommodityId = commodityId;
            CommodityName = commodityName;
            Amount = amount;
        }

        public int OrderItemId { get; set; }
        public int CommodityId { get; set; }
        public string CommodityName { get; set; }
        public int Amount { get; set; }
    }
}

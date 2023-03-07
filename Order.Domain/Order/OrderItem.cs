﻿namespace Order.Domain.Order
{
    /** Entity.
     */
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int CommodityId { get; set; }
        public string CommodityName { get; set; } = string.Empty;
        public int Amount { get; set; }
    }
}

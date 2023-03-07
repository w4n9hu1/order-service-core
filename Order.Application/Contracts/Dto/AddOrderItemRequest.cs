namespace Order.Application.Contracts.Dto
{
    public class AddOrderItemRequest
    {
        public int CommodityId { get; set; }
        public string CommodityName { get; set; } = string.Empty;
        public int Amount { get; set; }
    }
}

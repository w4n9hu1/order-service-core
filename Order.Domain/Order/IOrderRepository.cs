namespace Order.Domain.Order
{
    public interface IOrderRepository
    {
        Task SaveOrderAsync(Order order);
    }
}

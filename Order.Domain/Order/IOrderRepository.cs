namespace Order.Domain.Order
{
    /** Repository (interface): A Repository is a collection-like
    interface that is used by the Domain and Application
    Layers to access to the data persistence system (the
    database). It hides the complexity of the DBMS from the
    business code. Domain Layer contains the interfaces of the
    repositories
     */
    public interface IOrderRepository
    {
        Task<Order> GetAsync(int orderId);
        Task InsertAsync(Order order);
        Task UpdateAsync(Order order);
    }
}

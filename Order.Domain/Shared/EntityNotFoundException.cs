namespace Order.Domain.Shared
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string message) : base(message) { }
    }
}

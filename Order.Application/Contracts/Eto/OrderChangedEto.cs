namespace Order.Application.Contracts.Eto
{
    /// <summary>
    /// Eto is a suffix for Event Transfer Objects we use by convention.Not required.
    /// </summary>
    public class OrderChangedEto
    {
        public int EventType { get; set; }
        public int OrderId { get; set; }
        public string OrderCode { get; set; } = string.Empty;
    }
}

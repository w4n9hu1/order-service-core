using Order.Domain.Shared;

namespace Order.Domain.Order
{
    public struct Weight
    {
        public decimal Value { get; }
        public WeightUnit Unit { get; }
    }
}

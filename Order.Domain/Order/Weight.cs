using Order.Domain.Shared;

namespace Order.Domain.Order
{
    /** Value Object: A Value Object is another kind of domain
    object that is identified by its properties rather than a
    unique Id. That means two Value Objects with same
    properties are considered as the same object. Value
    objects are generally implemented as immutable and
    mostly are much simpler than the Entities.
     */
    public struct Weight
    {
        public decimal Value { get; }
        public WeightUnit Unit { get; }
    }
}

namespace Ordering.Domain.ValueObjects;

// Value Object representing the unique identifier for an OrderItem
public record OrderItemId
{
    public Guid Value { get; }
    private OrderItemId(Guid value) => Value = value;

    public static OrderItemId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
            throw new DomainException("OrderItemId cannot be an empty GUID.");
        return new OrderItemId(value);
    }
}

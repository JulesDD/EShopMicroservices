namespace Ordering.Domain.ValueObjects;

// Value Object representing the unique identifier for an Order
public record OrderId
{
    public Guid Value { get; }
    private OrderId(Guid value) => Value = value;

    public static OrderId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
            throw new DomainException("OrderId cannot be an empty GUID.");
        return new OrderId(value);
    }
}

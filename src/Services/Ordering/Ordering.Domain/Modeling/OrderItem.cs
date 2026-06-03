using Ordering.Domain.Abstractions;

namespace Ordering.Domain.Modeling;

public class OrderItem : Entity<Guid>
{
    // Constructor for creating a new OrderItem with specified details
    internal OrderItem(Guid orderId, Guid productId, int quantity, decimal price)
    {
        Id = Guid.NewGuid();
        OrderId = orderId;
        ProductId = productId;
        Quantity = quantity;
        Price = price;
    }
    public Guid OrderId { get; private set; } = default!;
    public Guid ProductId { get; private set; } = default!;
    public int Quantity { get; private set; } = default!;
    public decimal Price { get; private set; } = default!;

}

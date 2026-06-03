namespace Ordering.Domain.Enums.Models;

// This class represents a product in the ordering domain.
// It includes properties for the product's name and price, and a factory method to create new instances of the product with validation.
public class Product : Entity<ProductId>
{
    public string Name { get; private set; } = default!;
    public decimal Price { get; private set; } = default!;

    // Factory method to create a new product instance with validation.
    public static Product Create(ProductId id, string name, decimal price)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);

        var product = new Product
        {
            Id = id,
            Name = name,
            Price = price
        };

        return product;
    }
}

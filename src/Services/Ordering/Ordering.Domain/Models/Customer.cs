namespace Ordering.Domain.Enums.Models;

public class Customer : Entity<CustomerId>
{
    public string Name { get; private set; } = default!;
    public string Email { get; private set; } = default!;

    // Factory method to create a new customer instance
    public static Customer Create(CustomerId id, string name, string email)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(email);
        var customer = new Customer
        {
            Id = id,
            Name = name,
            Email = email
        };
        return customer;
    }
}
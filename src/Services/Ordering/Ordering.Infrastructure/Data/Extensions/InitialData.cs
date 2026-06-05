namespace Ordering.Infrastructure.Data.Extensions;

// This class provides initial data for seeding the database during development or testing. It contains a static property that returns a list of predefined customers to be added to the database if it is empty.
// This helps ensure that there is some data available for testing and development purposes without having to manually add it each time.
internal class InitialData
{
    // A static property that returns a list of predefined customers. Each customer is created using the Customer.
    // Create method, which takes a CustomerId, name, and email as parameters.
    // The CustomerId is generated using a Guid to ensure uniqueness.
    public static IEnumerable<Customer> Customers => new List<Customer>
    {
        Customer.Create(CustomerId.Of(new Guid("471ef931-9fe7-41af-b120-b9ab08b4b324")), "John Doe", "john.doe@example.com"),
        Customer.Create(CustomerId.Of(new Guid("5a1c2e3f-4b6d-4c8e-9f1a-2b3c4d5e6f78")), "Jane Smith", "jane.smith@example.com")
    };

    // A static property that returns a list of predefined products. Each product is created using the Product.Create method, which takes a ProductId, name, and price as parameters.
    public static IEnumerable<Product> Products => new List<Product>
    {
        Product.Create(ProductId.Of(new Guid("123e4567-e89b-12d3-a456-426614174000")), "IPhone 16", 999.99m),
        Product.Create(ProductId.Of(new Guid("123e4567-e89b-12d3-a456-426614174001")), "Samsung Galaxy S23", 499.99m),
        Product.Create(ProductId.Of(new Guid("123e4567-e89b-12d3-a456-426614174002")), "Google Pixel 8", 799.99m),
        Product.Create(ProductId.Of(new Guid("123e4567-e89b-12d3-a456-426614174003")), "MacBook Pro", 2799.99m)
    };

    // A static property that returns a list of predefined orders with their associated items.
    // Each order is created using the Order.Create method, which takes an OrderId, CustomerId, OrderName, shipping and billing addresses, and payment information as parameters.
    // The orders also include items added using the Add method, which takes a ProductId, quantity, and price as parameters.
    public static IEnumerable<Order> OrdersWithItems
    {
        get
        {
            var address1 = Address.Of("Jane", "Smith", "jane.smith@example.com", "1600 Pennsylvania Avenue NW, Washington", "United States", "District of Columbia", "205001");
            var address2 = Address.Of("John", "Doe", "john.doe@example.com", "10 Downing Street", "England", "Westminster", "SW1A2A");

            var payment1 = Payment.Of("Jane", "5555555555554444", "12/28", "355", 1);
            var payment2 = Payment.Of("John", "8885555555554444", "06/30", "222", 2);

            var order1 = Order.Create(
                            OrderId.Of(Guid.NewGuid()),
                            CustomerId.Of(new Guid("471ef931-9fe7-41af-b120-b9ab08b4b324")),
                            OrderName.Of("ORD_1"),
                            shippingAddress: address1,
                            billingAddress: address1,
                            payment1);
            order1.Add(ProductId.Of(new Guid("123e4567-e89b-12d3-a456-426614174000")), 2, 999.99m);
            order1.Add(ProductId.Of(new Guid("123e4567-e89b-12d3-a456-426614174001")), 1, 499.99m);

            var order2 = Order.Create(
                            OrderId.Of(Guid.NewGuid()),
                            CustomerId.Of(new Guid("5a1c2e3f-4b6d-4c8e-9f1a-2b3c4d5e6f78")),
                            OrderName.Of("ORD_2"),
                            shippingAddress: address2,
                            billingAddress: address2,
                            payment2);
            order2.Add(ProductId.Of(new Guid("123e4567-e89b-12d3-a456-426614174002")), 1, 799.99m);
            order2.Add(ProductId.Of(new Guid("123e4567-e89b-12d3-a456-426614174003")), 2, 2799.99m);

            return new List<Order> { order1, order2 };
        }
    }
}

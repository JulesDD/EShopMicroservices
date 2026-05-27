namespace Basket.API.Models;

//As the name implies. It's the model for an item in the cart
public class ShoppingCartItem
{
    public int Quantity { get; set; } = default!;
    public string Color { get; set; } = default!;
    public decimal Price { get; set; } = default!;
    public Guid ProductId { get; set; } = default!;
    public string ProductName { get; set; } = default!;

}

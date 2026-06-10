namespace Ordering.Application.Orders.EventHandlers.Integration;

public class BasketCheckoutEventHandler(ISender sender, ILogger<BasketCheckoutEventHandler> logger) : IConsumer<BasketCheckoutEvent>
{
    public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
    {
        logger.LogInformation("Integration Event Handled: {IntegrationEvent}", context.Message.GetType().Name);

        var command = MapToCreateOrderCommand(context.Message);
        await sender.Send(command);
    }
    
    // Creates a full order with incoming event data. Hardcoded... I could work on this later. 
    private CreateOrderCommand MapToCreateOrderCommand(BasketCheckoutEvent message)
    {
        var addressDto = new AddressDto(
            message.FirstName, 
            message.LastName, 
            message.EmailAddress, 
            message.AddressLine, 
            message.Country, 
            message.Province, 
            message.PostalCode);

        var paymentDto = new PaymentDto(
            message.CardName, 
            message.CardNumber, 
            message.Expiration, 
            message.CVV, 
            message.PaymentMethod);

        var orderId = Guid.NewGuid();

        var orderDto = new OrderDto(
            Id: orderId,
            CustomerId: message.CustomerId,
            OrderName: message.UserName,
            ShippingAddress: addressDto,
            BillingAddress: addressDto,
            Payment: paymentDto,
            Status: Ordering.Domain.Enums.OrderStatus.Pending,
            OrderItems:
            [
                new OrderItemDto(orderId, new Guid("123e4567-e89b-12d3-a456-426614174000"), 2, 999.99m),
                new OrderItemDto(orderId, new Guid("123e4567-e89b-12d3-a456-426614174001"), 1, 499.99m)
            ]);

        return new CreateOrderCommand(orderDto);
    }
}

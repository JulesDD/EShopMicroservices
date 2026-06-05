namespace Ordering.Application.Orders.Commands.UpdateOrder;

internal class UpdateOrderHandler(IApplicationDbContext dbContext) : ICommandHandler<UpdateOrderCommand, UpdateOrderResult>
{
    public async Task<UpdateOrderResult> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
    {
        //var orderId = OrderId.Of(command.OrderDto.Id);
        //var order = dbContext.Orders.FindAsync([orderId], cancellationToken: cancellationToken);

        //if (order is null) throw new OrderNotFoundException(command.OrderDto.Id);

        //UpdateOrderWithNewValues(order, command.OrderDto);

        //dbContext.Orders.Update(order);
        //await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateOrderResult(true);

    }

    private void UpdateOrderWithNewValues(ValueTask<Order?> order, OrderDto orderDto)
    {
        throw new NotImplementedException();
    }
}

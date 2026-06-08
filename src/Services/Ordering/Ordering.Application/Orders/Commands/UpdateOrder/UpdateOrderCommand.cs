namespace Ordering.Application.Orders.Commands.UpdateOrder;

public record UpdateOrderCommand(OrderDto Order) : ICommand<UpdateOrderResult>;

public record UpdateOrderResult(bool IsSuccess);

public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderCommandValidator()
    {
        RuleFor(c => c.Order.Id).NotEmpty().WithMessage("An Order Id is required");
        RuleFor(c => c.Order.OrderName).NotEmpty().WithMessage("A name is required");
        RuleFor(c => c.Order.CustomerId).NotEmpty().WithMessage("A Customer Id is required");
    }
}

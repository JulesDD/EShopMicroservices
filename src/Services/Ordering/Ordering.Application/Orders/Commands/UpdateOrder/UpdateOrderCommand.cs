namespace Ordering.Application.Orders.Commands.UpdateOrder;

public record UpdateOrderCommand(OrderDto OrderDto) : ICommand<UpdateOrderResult>;

public record UpdateOrderResult(bool IsSuccess);

public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderCommandValidator()
    {
        RuleFor(c => c.OrderDto.Id).NotEmpty().WithMessage("An Order Id is required");
        RuleFor(c => c.OrderDto.OrderName).NotEmpty().WithMessage("A name is required");
        RuleFor(c => c.OrderDto.CustomerId).NotEmpty().WithMessage("A Customer Id is required");
    }
}

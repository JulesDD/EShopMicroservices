using FluentValidation;

namespace Ordering.Application.Orders.Commands.CreateOrder;

public record CreateOrderCommand(OrderDto OrderDto) : ICommand<CreateOrderResult>;

public record CreateOrderResult(Guid Id);

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(x => x.OrderDto.OrderName).NotEmpty().WithMessage("An order name is required");
        RuleFor(x => x.OrderDto.CustomerId).NotEmpty().WithMessage("A customer id is required");
        RuleFor(x => x.OrderDto.OrderItems).NotEmpty().WithMessage("An item should be included in this order.");
    }
}
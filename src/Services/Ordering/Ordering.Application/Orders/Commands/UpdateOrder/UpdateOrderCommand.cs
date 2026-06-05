using FluentValidation;

namespace Ordering.Application.Orders.Commands.UpdateOrder;

public record UpdateOrderCommand(OrderDto OrderDto) : ICommand<UpdateOrderResult>;

public record UpdateOrderResult(bool IsSuccess);

public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderCommandValidator()
    {
        RuleFor(c => c.OrderDto.Id).NotEmpty().WithMessage("An Id is required");
        RuleFor(c => c.OrderDto.OrderName).NotEmpty().WithMessage("A name is required");
        RuleFor(c => c.OrderDto.CustomerId).NotEmpty().WithMessage("A customerId is required");
    }
}

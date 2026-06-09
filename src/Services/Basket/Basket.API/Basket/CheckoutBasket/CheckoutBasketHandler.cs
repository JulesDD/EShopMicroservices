using BuildingBlocks.Messaging.Events;
using MassTransit;

namespace Basket.API.Basket.CheckoutBasket;

public record CheckoutBasketCommand(BasketCheckoutDto BasketCheckoutDto) : ICommand<CheckoutBasketResult>;

public record CheckoutBasketResult(bool IsSuccess);

public class CheckoutCommandValidator : AbstractValidator<CheckoutBasketCommand>
{
    public CheckoutCommandValidator()
    {
        RuleFor(x => x.BasketCheckoutDto).NotNull().WithMessage("BasketCheckout cannot be null");
        RuleFor(x => x.BasketCheckoutDto.UserName).NotEmpty().WithMessage("BasketCheckout name cannot be empty");
    }
}
public class CheckoutBasketCommandHandler(IBasketRepository repository, IPublishEndpoint publishEndpoint) 
    : ICommandHandler<CheckoutBasketCommand, CheckoutBasketResult>
{
    public async Task<CheckoutBasketResult> Handle(CheckoutBasketCommand command, CancellationToken cancellationToken)
    {
        var basket = await repository.GetBasket(command.BasketCheckoutDto.UserName, cancellationToken);

        if (basket is null) return new CheckoutBasketResult(false);

        var eventMessage = command.BasketCheckoutDto.Adapt<BasketCheckoutEvent>();
        eventMessage.TotalPrice = basket.TotalPrice;

        await publishEndpoint.Publish(eventMessage, cancellationToken);

        await repository.DeleteBasket(command.BasketCheckoutDto.UserName, cancellationToken);

        return new CheckoutBasketResult(true);
    }
}

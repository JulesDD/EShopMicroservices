using System.Text.Json;

namespace Basket.API.Data;

public class CacheBasketRepoistory(IBasketRepository repository, IDistributedCache cache) : IBasketRepository
{
    public async Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken = default)
    {
        await repository.DeleteBasket(userName, cancellationToken);
        await cache.RemoveAsync(userName, cancellationToken);
        return true;
    }

    public async Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellationToken)
    {
        var cacheBasket = await cache.GetStringAsync(userName, cancellationToken);
        if (!string.IsNullOrEmpty(cacheBasket))
        {
            return JsonSerializer.Deserialize<ShoppingCart>(cacheBasket)!;
        }

        var cart = await repository.GetBasket(userName, cancellationToken);
        await cache.SetStringAsync(userName, JsonSerializer.Serialize(cart), cancellationToken);
        return cart;
    }

    public async Task<ShoppingCart> StoreBasket(ShoppingCart cart, CancellationToken cancellationToken)
    {
        await repository.StoreBasket(cart, cancellationToken);
        await cache.SetStringAsync(cart.UserName, JsonSerializer.Serialize(cart), cancellationToken);
        return cart;

    }
}

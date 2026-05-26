using BuildingBlocks.Exceptions;

namespace Catalog.API.Exceptions;

// This exception is thrown when a product is not found in the database. It can be used to return a 404 Not Found response to the client.
public class ProductNotFoundException : NotFoundException
{
    public ProductNotFoundException(Guid Id) : base("Product", Id)
    {
        //logger.LogWarning("Product with id {Id} not found", query.Id);
        //throw new NotFoundException($"Product with id {query.Id} not found")
    }
}

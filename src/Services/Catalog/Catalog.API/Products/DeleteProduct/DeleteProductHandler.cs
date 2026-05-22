namespace Catalog.API.Products.DeleteProduct;

public record DeleteProductCommand(Guid id) : ICommand<DeleteProductResult>;

public record DeleteProductResult(bool IsSucess);

internal class DeleteProductComandHandler(IDocumentSession session, ILogger<DeleteProductComandHandler> logger) : ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
    public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation("Handling DeleteCommandHandler for product Id: {ProductId}", command.id);
        session.Delete<Product>(command.id);
        await session.SaveChangesAsync(cancellationToken);

        return new DeleteProductResult(true);
    }
}

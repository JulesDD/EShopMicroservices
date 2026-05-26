using Catalog.API.Products.CreateProduct;

namespace Catalog.API.Products.UpdateProduct;

public record UpdateProductCommand(
    Guid Id, 
    string Name, 
    string Description, 
    decimal Price,
    string ImageFile,
    List<string> Categories) 
    : ICommand<UpdateProductResult>;

public record UpdateProductResult(bool IsSuccess);

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("An Id must be provided");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Categories).NotEmpty().WithMessage("Catory field is required");
        RuleFor(x => x.ImageFile).NotEmpty().WithMessage("An Image file is required");
        RuleFor(x => x.Price).GreaterThan(0).WithMessage("Please insert a price greater than 0");

    }
}
internal class UpdateProductCommandHandler(IDocumentSession session) 
    : ICommandHandler<UpdateProductCommand, UpdateProductResult>
{
    public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var product = await session.LoadAsync<Product>(command.Id, cancellationToken);
        if(product is null)
        {
            throw new ProductNotFoundException(command.Id);
        }
        product.Name = command.Name;
        product.Description = command.Description;
        product.Price = command.Price;
        product.Categories = command.Categories;
        product.ImageFile = command.ImageFile;

        session.Update(product);
        await session.SaveChangesAsync(cancellationToken);
        return new UpdateProductResult(true);
    }
}

namespace Catalog.API.Products.GetProducts;

// This record can be used to define the response model for the get products endpoint, such as a list of products.
public record GetProductsResponse(IEnumerable<Product> Products);
public class GetProductsEndpoint : ICarterModule
{
    // This method is called to add routes to the application.
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async (ISender sender) =>
        {
            var query = new GetProductsQuery();
            var result = await sender.Send(query);
            var response = result.Adapt<GetProductsResponse>();
            return Results.Ok(response);    
        })
            .WithName("GetProducts")
            .Produces<GetProductsResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Gets a list of products.")
            .WithDescription("Get Products");
    }
}

namespace Catalog.API.Products.CreateProduct;

// This record can be used to define the request and response models for the create product endpoint.
public record CreateProductRequest(
    string Name,
    List<string> Categories,
    string Description,
    string ImageFile,
    decimal Price
);

// This record can be used to define the response model for the create product endpoint, such as the ID of the created product.
public record CreateProductResponse(Guid Id);

// This class defines the endpoint for creating a new product. It implements the ICarterModule interface to add routes to the application.
public class CreatedProductEndpoint : ICarterModule
{
    // This method is called to add routes to the application.
    // It maps a POST request to the "/products" endpoint, which takes a CreateProductRequest and returns a CreateProductResponse.
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/products", async (CreateProductRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateProductCommand>();
            var result = await sender.Send(command);
            var response = result.Adapt<CreateProductResponse>();

            return Results.Created($"/products/{response.Id}", response);

        })
            .WithName("CreateProduct")
            .Produces<CreateProductResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Creates a new product.")
            .WithDescription("Create Product");
    }
}
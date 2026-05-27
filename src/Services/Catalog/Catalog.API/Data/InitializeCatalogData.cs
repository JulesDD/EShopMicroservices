namespace Catalog.API.Data;

public class InitializeCatalogData : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        using var session = store.LightweightSession();

        if (await session.Query<Product>().AnyAsync())
            return;

        //UPSERT will be use to provide for existing records
        session.Store<Product>(GetPreconfigureProducts());
        await session.SaveChangesAsync();
    }

    // These are the existing records
    private static IEnumerable<Product> GetPreconfigureProducts() => new List<Product>
    {
        new Product()
        {
            Id = new Guid("4c382c7a-a372-48db-aaea-07349cc2d1dd"),
            Name = "IPhone 16 Plus",
            Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
            ImageFile = "product-1.png",
            Price = 950,
            Categories = new List<string> { "Smart Phone" }
        },
        new Product()
        {
            Id = new Guid("6a2bae7a-459a-4fa9-86d2-5b39029882db"),
            Name = "M5 Macbook Pro",
            Description = "It's a macbook pro. Djs love this product",
            ImageFile = "product-2.png",
            Price = 2000,
            Categories = new List<string> { "Computer Appliance" }
        },
        new Product()
        {
            Id = new Guid("4f136e9f-ff8c-4c1f-9a33-d12f689bdab8"),
            Name = "MSI Cyborg 15",
            Description = "You are a gaming laptop diguised as a working software developer device.",
            ImageFile = "product-3.png",
            Price = 650,
            Categories = new List<string> { "Computer Appliance" }
        },
        new Product()
        {
            Id = new Guid("6ec1297b-ec0a-4aa1-be25-6726e3b51a27"),
            Name = "Xiaomi Mi 9",
            Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
            ImageFile = "product-4.png",
            Price = 470.00M,
            Categories = new List<string> { "White Appliances" }
        },
        new Product()
        {
            Id = new Guid("b786103d-c621-4f5a-b498-23452610f88c"),
            Name = "HTC U11+ Plus",
            Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
            ImageFile = "product-5.png",
            Price = 380.00M,
            Categories = new List<string> { "Smart Phone" }
        },
        new Product()
        {
            Id = new Guid("b2a11396-14af-447f-a50d-d2b329753745"),
            Name = "Sony Playstation 5",
            Description = "Your kids or boyfriend will love you. Your bank account wouldn't",
            ImageFile = "product-6.png",
            Price = 800,
            Categories = new List<string> { "Home Appliance" }
        },
        new Product()
        {
            Id = new Guid("414f6b1c-71b9-4034-bb0f-eacc719f6ccc"),
            Name = "X-Box Series S",
            Description = "No one will love you for buying this.",
            ImageFile = "product-7.png",
            Price = 600,
            Categories = new List<string> { "Home Appliance" }
        }
    };

}

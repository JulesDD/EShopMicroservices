namespace Ordering.Infrastructure.Data;

// This class represents the Entity Framework Core database context for the Ordering service.
// It inherits from DbContext and is configured to use dependency injection for its options.
// The OnModelCreating method is overridden to allow for further configuration of the model, but currently it just calls the base implementation.
public class ApplicationDbContext : DbContext
{
    // The constructor takes DbContextOptions and passes them to the base class constructor
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    // DbSet properties represent the tables in the database. Each DbSet corresponds to a specific entity type (Customer, Order, Product, OrderItem).
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();

    // The OnModelCreating method is where you can configure the model using the Fluent API. 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}

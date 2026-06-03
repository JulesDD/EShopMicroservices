namespace Ordering.Infrastructure.Data.Configurations;

// This class configures the OrderItem entity for Entity Framework Core, specifying how it should be mapped to the database.
public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    // This method is called by the Entity Framework Core runtime to configure the OrderItem entity.
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(oi => oi.Id);
        builder.Property(oi => oi.Id).HasConversion(
            orderItemId => orderItemId.Value, 
            dbId => OrderItemId.Of(dbId));

        builder.HasOne<Product>()
            .WithMany()
            .HasForeignKey(oi => oi.ProductId);

        builder.Property(oi => oi.Quantity).IsRequired();
        builder.Property(oi => oi.Price).IsRequired();
    }
}

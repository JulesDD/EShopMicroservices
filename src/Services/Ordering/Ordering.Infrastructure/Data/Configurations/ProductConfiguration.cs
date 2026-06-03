namespace Ordering.Infrastructure.Data.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        // Configure the Product entity
        builder.HasKey(p => p.Id);

        // Configure the conversion for ProductId value object
        builder.Property(p => p.Id).HasConversion(
            productId => productId.Value,
            dbId => ProductId.Of(dbId));

        // Configure Name and Price properties
        builder.Property(p => p.Name).HasMaxLength(200).IsRequired();
        builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
    }
}

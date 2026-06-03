namespace Ordering.Infrastructure.Data.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        // Configure the Customer entity
        builder.HasKey(c => c.Id);

        // Configure the conversion for CustomerId value object
        builder.Property(c => c.Id).HasConversion(
            customerId => customerId.Value,
            dbId => CustomerId.Of(dbId));

        // Configure Name and Email properties
        builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
        builder.Property(c => c.Email).HasMaxLength(100);
        builder.HasIndex(c => c.Email).IsUnique();
    }
}

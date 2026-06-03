namespace Ordering.Domain.ValueObjects;

public class Address
{
    public string FirstName { get; } = default!;
    public string LastName { get; } = default!;
    public string? EmaiAddress { get; } = default!;
    public string AddressLine { get; } = default!;
    public string Country { get; } = default!;
    public string Province { get; } = default!;
    public string ZipCode { get; } = default!;
}

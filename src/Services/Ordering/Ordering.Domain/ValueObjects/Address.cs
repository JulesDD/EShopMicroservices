namespace Ordering.Domain.ValueObjects;
// Value object representing an address in the system
public class Address
{
    public string FirstName { get; } = default!;
    public string LastName { get; } = default!;
    public string? EmailAddress { get; } = default!;
    public string AddressLine { get; } = default!;
    public string Country { get; } = default!;
    public string Province { get; } = default!;
    public string ZipCode { get; } = default!;

    // Factory method to create a new Address instance
    protected Address() 
    { 
    }

    // Static factory method to create a new Address instance
    private Address(string firstName, string lastName, string? emailAddress, string addressLine, string country, string province, string zipCode)
    {
        FirstName = firstName;
        LastName = lastName;
        EmailAddress = emailAddress;
        AddressLine = addressLine;
        Country = country;
        Province = province;
        ZipCode = zipCode;
    }

    public static Address Of(string firstName, string lastName, string? emailAddress, string addressLine, string country, string province, string zipCode)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(emailAddress);
        ArgumentException.ThrowIfNullOrWhiteSpace(addressLine);

        return new Address(firstName, lastName, emailAddress, addressLine, country, province, zipCode);
    }
}

namespace Bookify.Domain.Entities.Apratment
{
    public record Address //Value Object
    (
        string Country,
        string State,
        string zipCode,
        string city,
        string street
    );
}

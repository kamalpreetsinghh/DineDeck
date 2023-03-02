using DineDeck.Domain.Common.Models;

namespace DineDeck.Domain.DinnerAggregate.ValueObjects;

public sealed class Location : ValueObject
{
    public string Name { get; private set; } = null!;
    public string Address { get; private set; } = null!;
    public double Latitude { get; private set; }
    public double Longitude { get; private set; }

    private Location() { }

    private Location(
        string name,
        string address,
        double latitude,
        double longitude)
    {
        Name = name;
        Address = address;
        Latitude = latitude;
        Longitude = longitude;
    }

    public static Location Create(
        string name,
        string address,
        double latitude,
        double longitude)
    {
        return new Location(
            name,
            address,
            latitude,
            longitude);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
        yield return Address;
        yield return Latitude;
        yield return Longitude;
    }
}
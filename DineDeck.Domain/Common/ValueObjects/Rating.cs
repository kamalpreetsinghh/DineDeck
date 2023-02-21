using DineDeck.Domain.Common.Models;

namespace DineDeck.Domain.Common.ValueObjects;

public sealed class Rating : ValueObject
{
    public double Value { get; private set; }

    public Rating(double value)
    {
        Value = value;
    }

    public static Rating CreateNew(double rating = 0)
    {
        return new Rating(rating);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}

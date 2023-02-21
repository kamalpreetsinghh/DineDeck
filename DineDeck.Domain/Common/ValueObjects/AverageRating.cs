using DineDeck.Domain.Common.Models;

namespace DineDeck.Domain.Common.ValueObjects;

public sealed class AverageRating : ValueObject
{
    public double Value { get; private set; }
    public int NumberOfRatings { get; private set; }

    public AverageRating(double value, int numberOfRatings)
    {
        Value = value;
        NumberOfRatings = numberOfRatings;
    }

    public static AverageRating CreateNew(double rating = 0, int numberOfRatings = 0)
    {
        return new AverageRating(rating, numberOfRatings);
    }

    public void AddNewRating(Rating rating)
    {
        Value = ((Value * NumberOfRatings) + rating.Value) / (NumberOfRatings + 1);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}

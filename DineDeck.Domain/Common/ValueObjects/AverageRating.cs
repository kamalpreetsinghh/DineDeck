using DineDeck.Domain.Common.Models;

namespace DineDeck.Domain.Common.ValueObjects;

public sealed class AverageRating : ValueObject
{
    public double Value { get; private set; }
    public int NumRatings { get; private set; }

    private AverageRating() { }

    private AverageRating(double value, int numRatings)
    {
        Value = value;
        NumRatings = numRatings;
    }

    public static AverageRating CreateNew(double rating = 0, int numRatings = 0)
    {
        return new AverageRating(rating, numRatings);
    }

    public void AddNewRating(int rating)
    {
        Value = ((Value * NumRatings) + rating) / ++NumRatings;
    }

    public void RemoveRating(int rating)
    {
        Value = ((Value * NumRatings) - rating) / --NumRatings;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
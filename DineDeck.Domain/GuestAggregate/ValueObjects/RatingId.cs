using DineDeck.Domain.Common.Models;

namespace DineDeck.Domain.GuestAggregate.ValueObjects;

public sealed class RatingId : ValueObject
{
    public Guid Value { get; private set; }

    private RatingId(Guid value)
    {
        Value = value;
    }

    public static RatingId CreateUnique()
    {
        return new RatingId(Guid.NewGuid());
    }

    public static RatingId Create(Guid value)
    {
        return new RatingId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}